using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace SatteliteManagment.Orientation
{
    public enum GizmoMode
    {
        Global,
        Local
    }

    internal class OrientationRegulator
    {
        private HelixViewport3D viewport;
        public HelixViewport3D Viewport => viewport;

        private readonly ModelVisual3D modelRoot;

        private Model3D model;

        private Point3D _rotationCenter;

        private ElementHost elementHost;

        private OrientationSender sender;

        public bool historyMode { get; set;} = false;

        //Current orientation values
        System.Windows.Forms.Label labelRoll;
        System.Windows.Forms.Label labelPitch;
        System.Windows.Forms.Label labelYaw;

        NumericUpDown NumericUpDownRoll;
        NumericUpDown NumericUpDownPitch;
        NumericUpDown NumericUpDownYaw;
        private float _roll;
        private float _pitch;
        private float _yaw;
        //gizmo features
        private GizmoMode _gizmoMode = GizmoMode.Local;
        private bool _gizmoVisible = true;

        private const double GizmoSize = 100.0;

        private LinesVisual3D _axisX;
        private LinesVisual3D _axisY;
        private LinesVisual3D _axisZ;

        public OrientationRegulator( ElementHost elementHost, NumericUpDown NumericUpDownRoll, NumericUpDown NumericUpDownPitch, NumericUpDown NumericUpDownYaw,
                    System.Windows.Forms.Label labelRoll,
                    System.Windows.Forms.Label labelPitch,
                    System.Windows.Forms.Label labelYaw,
                    OrientationSender sender)
        {
            viewport = new HelixViewport3D();
            modelRoot = new ModelVisual3D();

            this.elementHost = elementHost;
            this.NumericUpDownRoll = NumericUpDownRoll;
            this.NumericUpDownPitch = NumericUpDownPitch;
            this.NumericUpDownYaw = NumericUpDownYaw;

            this.labelRoll = labelRoll;
            this.labelPitch = labelPitch;
            this.labelYaw = labelYaw;

            this.sender = sender;
            InitializeScene();

        }

        private void InitializeScene()
        {
            viewport.Children.Add(new SunLight());

            viewport.Children.Add(modelRoot);

            viewport.ShowCoordinateSystem = true;
            CreateGizmo();

        }

        public void LoadModel(string path)
        {
            var reader = new StLReader();

            model = reader.Read(path);

            modelRoot.Content = model;

            Rect3D bounds = model.Bounds;

            _rotationCenter = new Point3D(
                bounds.X + bounds.SizeX / 2.0,
                bounds.Y + bounds.SizeY / 2.0,
                bounds.Z + bounds.SizeZ / 2.0);

            _roll = 0;
            _pitch = 0;
            _yaw = 0;

            UpdateModelTransform();
            UpdateGizmo();

            viewport.ZoomExtents();
        }

        public void ClearModel()
        {
            modelRoot.Content = null;

            model = null;
        }
        private void CreateGizmo()
        {
            _axisX = new LinesVisual3D
            {
                Thickness = 3,
                Color = Colors.Red
            };

            _axisY = new LinesVisual3D
            {
                Thickness = 3,
                Color = Colors.Green
            };

            _axisZ = new LinesVisual3D
            {
                Thickness = 3,
                Color = Colors.Blue
            };

            viewport.Children.Add(_axisX);
            viewport.Children.Add(_axisY);
            viewport.Children.Add(_axisZ);

            UpdateGizmo();
        }
        private void UpdateGizmo()
        {
            if (!_gizmoVisible)
                return;

            if (_axisX == null ||
                _axisY == null ||
                _axisZ == null)
                return;

            Vector3D x = new Vector3D(1, 0, 0);
            Vector3D y = new Vector3D(0, 1, 0);
            Vector3D z = new Vector3D(0, 0, 1);

            if (_gizmoMode == GizmoMode.Local)
            {
                Matrix3D matrix = CreateOrientationTransform().Value;

                x = matrix.Transform(x);
                y = matrix.Transform(y);
                z = matrix.Transform(z);
            }

            var center = _rotationCenter;

            _axisX.Points = new Point3DCollection
            {
                center,
                center + x * GizmoSize
            };

            _axisY.Points = new Point3DCollection
            {
                center,
                center + y * GizmoSize
            };

            _axisZ.Points = new Point3DCollection
            {
                center,
                center + z * GizmoSize
            };
        }
        private void UpdateModelTransform()
        {
            modelRoot.Transform = CreateOrientationTransform();
        }
        private Transform3DGroup CreateOrientationTransform()
        {
            var transform = new Transform3DGroup();

            transform.Children.Add(
                new RotateTransform3D(
                    new AxisAngleRotation3D(
                        new Vector3D(1, 0, 0),
                        _roll),
                    _rotationCenter.X,
                    _rotationCenter.Y,
                    _rotationCenter.Z));

            transform.Children.Add(
                new RotateTransform3D(
                    new AxisAngleRotation3D(
                        new Vector3D(0, 1, 0),
                        _pitch),
                    _rotationCenter.X,
                    _rotationCenter.Y,
                    _rotationCenter.Z));

            transform.Children.Add(
                new RotateTransform3D(
                    new AxisAngleRotation3D(
                        new Vector3D(0, 0, 1),
                        _yaw),
                    _rotationCenter.X,
                    _rotationCenter.Y,
                    _rotationCenter.Z));

            return transform;
        }
        public void SetGizmoMode(GizmoMode mode)
        {
            _gizmoMode = mode;

            UpdateGizmo();
        }
        public void SetGizmoVisible(bool visible)
        {
            _gizmoVisible = visible;

            UpdateGizmo();
            SetGizmoVisibility(visible);
        }
        private void SetGizmoVisibility(bool visible)
        {
            if (_axisX == null || _axisY == null || _axisZ == null)
                return;

            if (visible)
            {
                if (!viewport.Children.Contains(_axisX))
                    viewport.Children.Add(_axisX);

                if (!viewport.Children.Contains(_axisY))
                    viewport.Children.Add(_axisY);

                if (!viewport.Children.Contains(_axisZ))
                    viewport.Children.Add(_axisZ);
            }
            else
            {
                viewport.Children.Remove(_axisX);
                viewport.Children.Remove(_axisY);
                viewport.Children.Remove(_axisZ);
            }
        }
        //Устанавливаем центр вращения модели в ее геометрический центр
        //private void FindModelCenter()
        //{
        //    Rect3D bounds = model.Bounds;

        //    double centerX = bounds.X + bounds.SizeX / 2.0;
        //    double centerY = bounds.Y + bounds.SizeY / 2.0;
        //    double centerZ = bounds.Z + bounds.SizeZ / 2.0;

        //    _rotationCenter = new Point3D(
        //        centerX,
        //        centerY,
        //        centerZ);

        //    var marker = new SphereVisual3D
        //    {
        //        Center = _rotationCenter,
        //        Radius = 2,
        //        Material = new DiffuseMaterial(System.Windows.Media.Brushes.Red)
        //    };
        //    viewport.Children.Add(marker);  
        //}
        public void UpdateOrientation(float roll, float pitch, float yaw)
        {
            // Update the orientation values in the UI
            labelRoll.Text = roll.ToString();
            labelPitch.Text = pitch.ToString();
            labelYaw.Text = yaw.ToString();
            // Update the 3D model's orientation in the viewport
            // Assuming you have a method to set the orientation of your 3D model
            SetModelOrientation(roll, pitch, yaw);
        }
        public void UpdateOrientation()
        {
            UpdateOrientation((float)NumericUpDownRoll.Value, (float)NumericUpDownPitch.Value, (float)NumericUpDownYaw.Value);
        }
        public void SetModelOrientation(float roll,float pitch, float yaw)
        {
            _roll = roll;
            _pitch = pitch;
            _yaw = yaw;
            // Update the orientation values in the UI
            labelRoll.Text = roll.ToString();
            labelPitch.Text = pitch.ToString();
            labelYaw.Text = yaw.ToString();

            UpdateModelTransform();
            UpdateGizmo();
        }

        //public void SetModelOrientation(float roll, float pitch, float yaw)
        //{
        //    var transform = new Transform3DGroup();

        //    transform.Children.Add(
        //        new RotateTransform3D(
        //            new AxisAngleRotation3D(
        //                new Vector3D(1, 0, 0),
        //                roll),
        //            _rotationCenter.X,
        //            _rotationCenter.Y,
        //            _rotationCenter.Z));

        //    transform.Children.Add(
        //        new RotateTransform3D(
        //            new AxisAngleRotation3D(
        //                new Vector3D(0, 1, 0),
        //                pitch),
        //            _rotationCenter.X,
        //            _rotationCenter.Y,
        //            _rotationCenter.Z));

        //    transform.Children.Add(
        //        new RotateTransform3D(
        //            new AxisAngleRotation3D(
        //                new Vector3D(0, 0, 1),
        //                yaw),
        //            _rotationCenter.X,
        //            _rotationCenter.Y,
        //            _rotationCenter.Z));

        //    modelRoot.Transform = transform;
        //}

        // Заменяет текущий источник света в viewport на переданный ModelVisual3D (не трогая остальные объекты сцены)
        // Пока что не используется
        public void ReplaceLight(ModelVisual3D newLightVisual)
        {
            if (viewport == null || newLightVisual == null)
                return;

            int foundIndex = -1;

            for (int i = 0; i < viewport.Children.Count; i++)
            {
                if (viewport.Children[i] is ModelVisual3D mv && mv.Content is Light)
                {
                    foundIndex = i;
                    break;
                }
            }

            if (foundIndex >= 0)
            {
                // Заменяем существующий источник света на новый, сохраняя положение в коллекции
                viewport.Children.RemoveAt(foundIndex);
                viewport.Children.Insert(foundIndex, newLightVisual);
            }
            else
            {
                // Если источника света не было, вставляем новый в начало коллекции
                viewport.Children.Insert(0, newLightVisual);
            }
        }

        public void ReplaceLight(Light light)
        {
            if (light == null) return;
            var mv = new ModelVisual3D { Content = light };
            ReplaceLight(mv);
        }

    }
}
