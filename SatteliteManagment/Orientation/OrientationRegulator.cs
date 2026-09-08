using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media.Media3D;

namespace SatteliteManagment.Orientation
{
    internal class OrientationRegulator
    {
        private HelixViewport3D viewport;
        public HelixViewport3D Viewport => viewport;

        private readonly ModelVisual3D modelRoot;

        private Model3D model;

        private Point3D _rotationCenter;

        private ElementHost elementHost;

        private OrientationSender sender;

        //Current orientation values
        System.Windows.Forms.Label labelRoll;
        System.Windows.Forms.Label labelPitch;
        System.Windows.Forms.Label labelYaw;

        NumericUpDown NumericUpDownRoll;
        NumericUpDown NumericUpDownPitch;
        NumericUpDown NumericUpDownYaw;

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
        }


        public void LoadModel(string path)
        {
            var reader = new StLReader();

            model = reader.Read(path);

            modelRoot.Content = model;

            SetModelOrientation(0, 0, 0);

            viewport.ZoomExtents();
            FindModelCenter();
        }

        public void ClearModel()
        {
            modelRoot.Content = null;

            model = null;
        }

        //Устанавливаем центр вращения модели в ее геометрический центр
        private void FindModelCenter()
        {
            Rect3D bounds = model.Bounds;

            double centerX = bounds.X + bounds.SizeX / 2.0;
            double centerY = bounds.Y + bounds.SizeY / 2.0;
            double centerZ = bounds.Z + bounds.SizeZ / 2.0;

            _rotationCenter = new Point3D(
                centerX,
                centerY,
                centerZ);

            var marker = new SphereVisual3D
            {
                Center = _rotationCenter,
                Radius = 2,
                Material = new DiffuseMaterial(System.Windows.Media.Brushes.Red)
            };
            viewport.Children.Add(marker);  
        }
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

        public void SetModelOrientation(float roll, float pitch, float yaw)
        {
            var transform = new Transform3DGroup();

            transform.Children.Add(
                new RotateTransform3D(
                    new AxisAngleRotation3D(
                        new Vector3D(1, 0, 0),
                        roll),
                    _rotationCenter.X,
                    _rotationCenter.Y,
                    _rotationCenter.Z));

            transform.Children.Add(
                new RotateTransform3D(
                    new AxisAngleRotation3D(
                        new Vector3D(0, 1, 0),
                        pitch),
                    _rotationCenter.X,
                    _rotationCenter.Y,
                    _rotationCenter.Z));

            transform.Children.Add(
                new RotateTransform3D(
                    new AxisAngleRotation3D(
                        new Vector3D(0, 0, 1),
                        yaw),
                    _rotationCenter.X,
                    _rotationCenter.Y,
                    _rotationCenter.Z));

            modelRoot.Transform = transform;
        }

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
