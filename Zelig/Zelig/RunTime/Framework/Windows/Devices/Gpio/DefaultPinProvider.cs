﻿//
// Copyright (c) Microsoft Corporation.    All rights reserved.
//

using System;
using System.Runtime.CompilerServices;
using Windows.Devices.Gpio.Provider;
using Llilum = Microsoft.Llilum.Devices.Gpio;

namespace Windows.Devices.Gpio
{
    internal class DefaultPinProvider : IGpioPinProvider
    {
        private Llilum.GpioPin m_gpioPin;

        internal DefaultPinProvider(int pinNumber)
        {
            Llilum.GpioPin newPin = Llilum.GpioPin.TryCreateGpioPin(pinNumber);
            if (newPin == null)
            {
                throw new ArgumentException();
            }
            m_gpioPin = newPin;
        }

        public TimeSpan DebounceTimeout
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int PinNumber
        {
            get
            {
                return m_gpioPin.PinNumber;
            }
        }

        public GpioSharingMode SharingMode
        {
            get
            {
                return GpioSharingMode.Exclusive;
            }
        }

        public void Dispose()
        {
            m_gpioPin.Dispose();
        }

        public GpioPinDriveMode GetDriveMode()
        {
            switch (m_gpioPin.Mode)
            {
                case Llilum.PinMode.PullNone:
                    return (m_gpioPin.Direction == Llilum.PinDirection.Input) ? 
                        GpioPinDriveMode.Input : GpioPinDriveMode.Output;
                case Llilum.PinMode.PullDown:
                    return GpioPinDriveMode.InputPullDown;
                case Llilum.PinMode.PullUp:
                    return GpioPinDriveMode.InputPullUp;
            }
            throw new NotSupportedException();
        }

        public bool IsDriveModeSupported(GpioPinDriveMode driveMode)
        {
            switch (driveMode)
            {
                case GpioPinDriveMode.Input:
                case GpioPinDriveMode.Output:
                case GpioPinDriveMode.InputPullUp:
                case GpioPinDriveMode.InputPullDown:
                    return true;
                default:
                    return false;
            }
        }

        public GpioPinValue Read()
        {
            return (m_gpioPin.Read() == 0) ? GpioPinValue.Low : GpioPinValue.High;
        }

        public void SetPinDriveMode(GpioDriveMode driveMode)
        {
            switch (driveMode)
            {
                case GpioDriveMode.Input:
                    m_gpioPin.Mode = Llilum.PinMode.PullNone;
                    m_gpioPin.Direction = Llilum.PinDirection.Input;
                    break;

                case GpioDriveMode.Output:
                    m_gpioPin.Mode = Llilum.PinMode.PullDefault;
                    m_gpioPin.Direction = Llilum.PinDirection.Output;
                    break;

                case GpioDriveMode.InputPullUp:
                    m_gpioPin.Mode = Llilum.PinMode.PullUp;
                    m_gpioPin.Direction = Llilum.PinDirection.Input;
                    break;

                case GpioDriveMode.InputPullDown:
                    m_gpioPin.Mode = Llilum.PinMode.PullDown;
                    m_gpioPin.Direction = Llilum.PinDirection.Input;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        public void Write(GpioPinValue value)
        {
            m_gpioPin.Write((int)value);
        }
    }
}