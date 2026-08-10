using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SatteliteManagment
{
    internal class DeviceStatusManager
    {
        private readonly TreeView _treeView;
        private readonly Label _nameLabel;
        private readonly Label _typeLabel;
        private readonly Label _idLabel;
        private readonly Label _statusLabel;
        private readonly TextBox _metaTextBox;

        private readonly List<DeviceNode> _roots = new List<DeviceNode>();

        public DeviceStatusManager(TreeView treeView, Label nameLabel, Label typeLabel, Label idLabel, Label statusLabel, TextBox metaTextBox)
        {
            _treeView = treeView;
            _nameLabel = nameLabel;
            _typeLabel = typeLabel;
            _idLabel = idLabel;
            _statusLabel = statusLabel;
            _metaTextBox = metaTextBox;

            _treeView.CheckBoxes = false;
            _treeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
            _treeView.ItemHeight = 28;
            _treeView.AfterSelect += OnTreeNodeSelected;
            _treeView.DrawNode += OnTreeNodeDraw;
        }

        public void LoadFromFile(string filePath)
        {
            _roots.Clear();
            _roots.AddRange(DeviceTreeParser.ParseFromFile(filePath));
            RebuildTree();
        }

        private void RebuildTree()
        {
            _treeView.BeginUpdate();
            _treeView.Nodes.Clear();

            foreach (DeviceNode root in _roots)
            {
                _treeView.Nodes.Add(CreateTreeNode(root));
            }

            _treeView.ExpandAll();
            _treeView.EndUpdate();
        }

        private TreeNode CreateTreeNode(DeviceNode deviceNode)
        {
            TreeNode treeNode = new TreeNode(deviceNode.Name)
            {
                Tag = deviceNode
            };

            foreach (DeviceNode child in deviceNode.Children)
            {
                treeNode.Nodes.Add(CreateTreeNode(child));
            }

            return treeNode;
        }

        private void OnTreeNodeSelected(object sender, TreeViewEventArgs e)
        {
            if (!(e.Node?.Tag is DeviceNode node))
            {
                return;
            }

            _nameLabel.Text = $"Name: {node.Name}";
            _typeLabel.Text = $"Type: {node.Type}";
            _idLabel.Text = $"Id: {node.Id}";
            _statusLabel.Text = $"Status: {node.Status}";

            if (node.Meta.Count == 0)
            {
                _metaTextBox.Text = string.Empty;
                return;
            }

            _metaTextBox.Lines = node.Meta.Select(kv => $"{kv.Key} = {kv.Value}").ToArray();
        }

        private void OnTreeNodeDraw(object sender, DrawTreeNodeEventArgs e)
        {
            if (!(e.Node?.Tag is DeviceNode node))
            {
                e.DrawDefault = true;
                return;
            }

            bool isAttribute = node.Type == "attribute";
            if (!isAttribute)
            {
                e.DrawDefault = true;
                return;
            }

            bool isSelected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
            using (SolidBrush backBrush = new SolidBrush(_treeView.BackColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            string text = node.Name;
            Size textSize = TextRenderer.MeasureText(e.Graphics, text, _treeView.Font, Size.Empty, TextFormatFlags.NoPadding);
            Rectangle buttonRect = new Rectangle(
                e.Bounds.Left,
                e.Bounds.Top + 2,
                textSize.Width + 20,
                e.Bounds.Height - 4);

            Color fillColor = isSelected ? SystemColors.Highlight : SystemColors.ControlLight;
            Color borderColor = isSelected ? SystemColors.HighlightText : SystemColors.ControlDark;
            Color textColor = isSelected ? SystemColors.HighlightText : SystemColors.ControlText;

            using (SolidBrush fillBrush = new SolidBrush(fillColor))
            using (Pen borderPen = new Pen(borderColor))
            {
                e.Graphics.FillRectangle(fillBrush, buttonRect);
                e.Graphics.DrawRectangle(borderPen, buttonRect);
            }

            Rectangle textRect = new Rectangle(buttonRect.Left + 8, buttonRect.Top + 2, buttonRect.Width - 12, buttonRect.Height - 4);
            TextRenderer.DrawText(
                e.Graphics,
                text,
                _treeView.Font,
                textRect,
                textColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
        }
    }
}
