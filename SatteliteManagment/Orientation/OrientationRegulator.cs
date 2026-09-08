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


        private ElementHost elementHost;

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
                    System.Windows.Forms.Label labelYaw)
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
        }

        public void ClearModel()
        {
            modelRoot.Content = null;

            model = null;
        }

        public void UpdateOrientation(double roll, double pitch, double yaw)
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
            UpdateOrientation((double)NumericUpDownRoll.Value, (double)NumericUpDownPitch.Value, (double)NumericUpDownYaw.Value);
        }

        public void SetModelOrientation(
            double roll,
            double pitch,
            double yaw)
        {
            var transform = new Transform3DGroup();

            transform.Children.Add(
                new RotateTransform3D(
                    new AxisAngleRotation3D(
                        new Vector3D(1, 0, 0),
                        roll)));

            transform.Children.Add(
                new RotateTransform3D(
                    new AxisAngleRotation3D(
                        new Vector3D(0, 1, 0),
                        pitch)));

            transform.Children.Add(
                new RotateTransform3D(
                    new AxisAngleRotation3D(
                        new Vector3D(0, 0, 1),
                        yaw)));

            modelRoot.Transform = transform;
        }

    }
}
