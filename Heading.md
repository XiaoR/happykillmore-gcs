# Compass confusion #

There's a bit of confusion about what is actually shown on the GCS. Each protocol has it's own variables and not everything is supported by every device. It's safe to assume if you have a device with thermopiles or an IMU you should have access to at least two of the three parameters discussed here.

"Heading" represents the actual direction your plane is pointing in reference to magnetic north.

"Bearing" is the direction your plane is flying taking in to account that the wind may be pushing the plane in a direction other than what your heading is indicating.

"Yaw" is a dead-reckoning value from your auto-pilot's sensors generally indicating a turn of the plane on the Z axis (rudder turn).

That said, things can get more complicated depending upon your auto-pilot on how exactly each of these values are reported. If you have a magnetometer, heading or yaw may include a bias based on this sensor's readings.

The GCS generally uses heading or bearing values for both the compass instrument and the 3D model shown in Google Earth's heading updates. The 3D model instrument (not in Google Earth) uses pitch, roll and yaw. In the case of ArduPilot Mega, if you have only a GPS connected (no magnetometer) the "heading" value reported from the GPS (which is actually Bearing....how confusing) will be used for the compass and the Google Earth model. If you do have a magenetometer connected then the GPS heading and the magnetometer values will be combined and reported as a heading value and will be more accurate.

On the ground, when you hit connect with the GCS, you may notice that as you turn the physical plane, only the 3D instrument plane will turn, the compass and 3D model in Google Earth will continue to point in one direction. This is beacuse the GPS is not reporting a change in heading as you need some forward speed for the GPS to determine which way your plane is going. If you have a magnetometer connected, make sure you have set the MAG\_ENABLED parameter = 1 (and reboot your APM) or your magnetometer will not have any effect on the heading values from the APM.

You may also notice that on the ground, the Google Earth 3D model is erratic and constantly changing directions. The compass instrument will also swing wildly. This too can be normal as the GPS does not know which direction it is pointing and these heading changes are only based on the lat and long errors of the GPS unit. Different brands of GPS handle this differently and any time you have fewer than 5 satellites things are going to be erratic.

Currently, the GCS does not show bearing. I would like to add it in the future, but right now, if your plane only has a GPS, the compass shows bearing. If you have a magnetometer, then your compass shows heading. It can be confusing.