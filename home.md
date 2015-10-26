# Introduction #

At the most basic level, a ground control station (GCS) is a program designed to receive data streams from your plane and graphically display them on a computer on the ground. To use this GCS you don't necessarily need an auto-pilot. Bare minimum would be a GPS unit connected to an X-Bee transmitter in your plane and another X-Bee unit connected to your laptop on the ground. This would provide lat, long, speed, heading and altitude data. For pitch and roll (and possibly yaw) you would need an IMU board (like an ArduIMU) or an auto-pilot with an IMU or thermopiles connected. But all of this depends upon what you're trying to accomplish.

HappyKillmore's Ground Control station was built with one major underlying goal. Make it simple to use. The average user only needs to know what COM port and baud rate to select and that's it. Click the connect button and they're up and running. Protocol selection is automatic.

The program is graphics oriented. It is not an engineer's interface. Another goal for the software was to work on low resolution screens. Currently, the application can operate as small as 800X400 which is well suited for netbooks computers.

![http://www.happykillmore.com/software/hk_gcs/Small800X480.gif](http://www.happykillmore.com/software/hk_gcs/Small800X480.gif)

# Details #

  * **System Pre-requisites**
    * [.NET 2.0 Framework](http://www.microsoft.com/downloads/en/details.aspx?familyid=5b2c0358-915b-4eb5-9b1d-10e506da9d0f&displaylang=en) (Note: Vista and Windows 7 users, this is already insalled)
    * [Google Earth Plug-in](http://www.google.com/earth/explore/products/plugin.html)

  * **Supported GPS Protocols**
    * [NMEA](http://www.flytron.com/osd-headtrackers/15-simpleosd-gps-module.html)
    * [uBlox](http://store.diydrones.com/GS407_U_Blox5_GPS_4Hz_p/spk-gps-gs407.htm)
    * [SiRF (GeoNav only)](http://store.diydrones.com/EM_406_GPS_1Hz_p/em-406a.htm)
    * [MediaTek v1 (DIYdrones.com Custom Binary)](http://store.diydrones.com/MediaTek_MT3329_GPS_10Hz_Adapter_Basic_p/mt3329-02.htm)
    * [MediaTek v1.6 (DIYdrones.com Custom Binary)](http://store.diydrones.com/MediaTek_MT3329_GPS_10Hz_Adapter_Basic_p/mt3329-02.htm)

  * **Supported IMU Protocols**
    * [ArduIMU](http://code.google.com/p/ardu-imu/)

  * **Supported Auto-Pilot Protocols**
    * [ArduPilot Legacy (ASCII)](http://diydrones.com/profiles/blogs/ardupilot-main-page)
    * [ArduPilot Mega Binary](http://diydrones.com/profiles/blogs/ardupilot-mega-home-page)
    * [MatrixPilot (UavDevBoard)](http://diydrones.com/page/uav-devboard)
    * [AttoPilot](http://www.attopilotinternational.com/)
    * [MAVlink](http://pixhawk.ethz.ch/wiki/software/mavlink/start)
    * [FY21AP II](http://feiyutech.ning.com/)
    * [Gluonpilot](http://www.gluonpilot.com/wiki/Main_Page)

  * **Supported Languages**
    * English
    * Chinese-PRC
    * Chinese-Traditional
    * Danish
    * Español
    * Finnish
    * Française
    * Italiano
    * Polski
    * Português Brasileiro
    * Português
    * Romana
    * Russian
    * Slovensky
    * Türkçe
    * Urdu