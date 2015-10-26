# Moving GCS / Remote Camera Tracking #
Compatible with HK GCS 1.3.17 and newer.

**NOTE:** Use this at your own risk. I take no responsibility for any damage to your plane or equipment by using this feature.

---

## Moving GCS ##
In some cases, the ground control station maybe be mobile (i.e. located in a car or van used as a search and rescue vehicle). In this case, the ground station laptop will not have a fixed "home" location nor will the offset value for the antenna's "north" heading be fixed at a single value.

To use the Moving GCS feature, check the box labelled "Enable Moving GCS/Remote Camera Location". You'll need to connect an NMEA GPS to one of the computer's COM ports. Select the correct COM port and baud rate. Be sure to check the box "Use GPS Heading for Offset (Moving)" which will use the current heading value from the NMEA sentence to set the offset value as the vehicle moves. Once the vehicle becomes stationary, this value may change dramatically and unpredictably as GPS heading is only correct when moving.

**NOTE** You STILL must use the Tracking tab to enable the output location for the pan and tilt features of the antenna.


## Remote Camera Tracking ##
Remote cameras are those located at some distance away from the "home" location. It may be impractical to take the vehicle to each of the remote camera locations simply to set the home location for each camera.

To use the Remote Camera Tracking feature, check the box labelled "Enable Moving GCS/Remote Camera Location". You'll need to connect an NMEA GPS to one of the computer's COM ports. Select the correct COM port and baud rate. Be sure to uncheck the box "Use GPS Heading for Offset (Moving)" and manually set the offset on either the tracking or Moving GCS tabs (save value will be used for both). In this case, the camera is assumed to be on a tripod but capable of panning and tilting.

**NOTE** You STILL must use the Tracking tab to enable the output location for the pan and tilt features of the antenna.