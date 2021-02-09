
using System;
using Xamarin.Essentials;

namespace XamEssentials_Showcase.Features.Metrics
{
    public class MetricsPageVM : BasePageViewModel
    {
        SensorSpeed speed = SensorSpeed.Default;

        //private bool accelerometerIsToggled;
        //private bool barometerIsToggled;
        //private bool compassIsToggled;
        //private bool gyroscopeIsToggled;
        //private bool magnetometerIsToggled;
        //private bool orientationSensorIsToggled;
        private bool metricsAreToggled;
        public string accelerometerString;
        public string barometerString;
        public string compassString;
        public string gyroscopeString;
        public string magnetometerString;
        public string orientationSensorString;


        //public bool AccelerometerIsToggled
        //{
        //    get { return accelerometerIsToggled; }
        //    set
        //    {
        //        accelerometerIsToggled = value;
        //        ToggleAccelerometer(accelerometerIsToggled);
        //        RaisePropertyChanged();
        //    }
        //}
        //public bool BarometerIsToggled
        //{
        //    get { return barometerIsToggled; }
        //    set
        //    {
        //        barometerIsToggled = value;
        //        ToggleBarometer(barometerIsToggled);
        //        RaisePropertyChanged();
        //    }
        //}
        //public bool CompassIsToggled
        //{
        //    get { return compassIsToggled; }
        //    set
        //    {
        //        compassIsToggled = value;
        //        ToggleBarometer(compassIsToggled);
        //        RaisePropertyChanged();
        //    }
        //}
        //public bool GyroscopeIsToggled
        //{
        //    get { return gyroscopeIsToggled; }
        //    set
        //    {
        //        gyroscopeIsToggled = value;
        //        ToggleBarometer(gyroscopeIsToggled);
        //        RaisePropertyChanged();
        //    }
        //}
        //public bool MagnetometerIsToggled
        //{
        //    get { return magnetometerIsToggled; }
        //    set
        //    {
        //        magnetometerIsToggled = value;
        //        ToggleMagnetometer(MagnetometerIsToggled);
        //        RaisePropertyChanged();
        //    }
        //}
        //public bool OrientationSensorIsToggled
        //{
        //    get { return orientationSensorIsToggled; }
        //    set
        //    {
        //        orientationSensorIsToggled = value;
        //        ToggleOrientationSensor(orientationSensorIsToggled);
        //        RaisePropertyChanged();
        //    }
        //}

        public bool MetricsAreToggled
        {
            get { return metricsAreToggled; }
            set
            {
                metricsAreToggled = value;
                ToggleMetrics(metricsAreToggled);
                RaisePropertyChanged();
            }
        }

        public string AccelterometerString
        {
            get { return accelerometerString; }
            set
            {
                accelerometerString = value;
                RaisePropertyChanged();
            }
        }
        public string BarometerString
        {
            get { return barometerString; }
            set
            {
                barometerString = value;
                RaisePropertyChanged();
            }
        }
        public string CompassString
        {
            get { return compassString; }
            set
            {
                compassString = value;
                RaisePropertyChanged();
            }
        }
        public string GyroscopeString
        {
            get { return gyroscopeString; }
            set
            {
                gyroscopeString = value;
                RaisePropertyChanged();
            }
        }
        public string MagnetometerString
        {
            get { return magnetometerString; }
            set
            {
                magnetometerString = value;
                RaisePropertyChanged();
            }
        }
        public string OrientationSensorString
        {
            get { return orientationSensorString; }
            set
            {
                orientationSensorString = value;
                RaisePropertyChanged();
            }
        }

        public MetricsPageVM()
        {
            AccelterometerString = "En Attente...";
            BarometerString = "En Attente...";
            CompassString = "En Attente...";
            GyroscopeString = "En Attente...";
            MagnetometerString = "En Attente...";
            OrientationSensorString = "En Attente...";

            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Barometer.ReadingChanged += Barometer_ReadingChanged;
            Compass.ReadingChanged += Compass_ReadingChanged;
            Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
            Magnetometer.ReadingChanged += Magnetometer_ReadingChanged;
            OrientationSensor.ReadingChanged += OrientationSensor_ReadingChanged;
        }

        public void ToggleMetrics(bool isToogled)
        {
            try
            {
                if (isToogled)
                {      
                    Accelerometer.Start(speed);
                    //Barometer.Start(speed);
                    Compass.Start(speed);
                    Gyroscope.Start(speed);
                    Magnetometer.Start(speed);
                    OrientationSensor.Start(speed);

                }
                else
                {
                    Accelerometer.Stop();
                    //Barometer.Stop();
                    Compass.Stop();
                    Gyroscope.Stop();
                    Magnetometer.Stop();
                    OrientationSensor.Stop();
                }
            }
            catch (FeatureNotSupportedException)
            {
                ShowNotSupportedError();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            AccelterometerString = ($"Mesure: X: {data.Acceleration.X}, Y: {data.Acceleration.Y}, Z: {data.Acceleration.Z}");
        }

        void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
        {
            var data = e.Reading;
            BarometerString = ($"Mesure: Pressure: {data.PressureInHectopascals} hectopascals");
        }

        void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            var data = e.Reading;
            CompassString = ($"Mesure: {data.HeadingMagneticNorth} degrees");
        }

        void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            var data = e.Reading;
            GyroscopeString = ($"Mesure: X: {data.AngularVelocity.X}, Y: {data.AngularVelocity.Y}, Z: {data.AngularVelocity.Z}");
        }

        void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
        {
            var data = e.Reading;
            MagnetometerString = ($"Mesure: X: {data.MagneticField.X}, Y: {data.MagneticField.Y}, Z: {data.MagneticField.Z}");
        }

        void OrientationSensor_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            var data = e.Reading;
            OrientationSensorString = ($"Mesure: X: {data.Orientation.X}, Y: {data.Orientation.Y}, Z: {data.Orientation.Z}, W: {data.Orientation.W}");
        }

        //public void ToggleAccelerometer(bool isToggled)
        //{
        //    try
        //    {
        //        if (isToggled)
        //            Accelerometer.Start(speed);
        //        else
        //            Accelerometer.Stop();

        //    }
        //    catch (FeatureNotSupportedException fnsEx)
        //    {
        //        ShowNotSupportedError();
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowError(ex.Message);
        //    }
        //}

        //public void ToggleBarometer(bool isToogled)
        //{
        //    try
        //    {
        //        if (isToogled)
        //            Barometer.Stop();
        //        else
        //            Barometer.Start(speed);
        //    }
        //    catch (FeatureNotSupportedException fnsEx)
        //    {
        //        // Feature not supported on device
        //    }
        //    catch (Exception ex)
        //    {
        //        // Other error has occurred.
        //    }
        //}

        //public void ToggleCompass(bool isToogled)
        //{
        //    try
        //    {
        //        if (isToogled)
        //            Compass.Stop();
        //        else
        //            Compass.Start(speed);
        //    }
        //    catch (FeatureNotSupportedException fnsEx)
        //    {
        //        // Feature not supported on device
        //    }
        //    catch (Exception ex)
        //    {
        //        // Other error has occurred.
        //    }
        //}

        //public void ToggleGyroscope(bool isToogled)
        //{
        //    try
        //    {
        //        if (isToogled)
        //            Gyroscope.Stop();
        //        else
        //            Gyroscope.Start(speed);
        //    }
        //    catch (FeatureNotSupportedException fnsEx)
        //    {
        //        // Feature not supported on device
        //    }
        //    catch (Exception ex)
        //    {
        //        // Other error has occurred.
        //    }
        //}

        //public void ToggleMagnetometer(bool isToogled)
        //{
        //    try
        //    {
        //        if (isToogled)
        //            Magnetometer.Stop();
        //        else
        //            Magnetometer.Start(speed);
        //    }
        //    catch (FeatureNotSupportedException fnsEx)
        //    {
        //        // Feature not supported on device
        //    }
        //    catch (Exception ex)
        //    {
        //        // Other error has occurred.
        //    }
        //}

        //public void ToggleOrientationSensor(bool isToogled)
        //{
        //    try
        //    {
        //        if (isToogled)
        //            OrientationSensor.Stop();
        //        else
        //            OrientationSensor.Start(speed);
        //    }
        //    catch (FeatureNotSupportedException fnsEx)
        //    {
        //        // Feature not supported on device
        //    }
        //    catch (Exception ex)
        //    {
        //        // Other error has occurred.
        //    }
        //}

    }
}
