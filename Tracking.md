# Antenna Tracking #
Compatible with HK GCS 1.1.32 and newer.

**NOTE:** Use this at your own risk. I take no responsibility for any damage to your plane or equipment by using this feature.

---

## General Comments ##
Your GPS has a 1.5 - 2.0 second lag! This tracker will actually be pointing to where your plane was 2 seconds ago...so take care a close range and high speeds.

The antenna tracker data will not start to flow (for PanTilt and Heading output types) until a home location has been set and the connect button is clicked on the tracking tab. In situations where something has been set incorrectly and you need to get your antenna pointed in the right direction quickly, change the "Hertz" setting for the tracker to "None" and use the sliders on the right to manually move the tracker.

The purpose of this project was to create a cheap, simple, off-the-shelf solution for antenna tracking. Feel free to make your own hardware if you'd like. The serial protocols are very simple and there isn't much data parsing required. It is possible to make an antenna tracking controller for just a few dollars (antenna not included, of course).

If you want to buy all the components, you'll need a soldering iron, an ArduPilot original (http://www.sparkfun.com/products/8785), some straight headers (http://www.sparkfun.com/products/116), and 2 servos.

---

## Output Types ##
**ArduTracker** - Sends servo settings for pan and tilt servos ranging from 0 to 3000 and is completely GCS controlled and does not require any intelligence from the tracker's microcontroller. There is a calibration (end-point setup) in the GCS which allows servo travel and full travel angle to be specified. Once calibrated, the "north" angle must simply be set at the field. See Tracker Offset below.

&lt;BR&gt;



&lt;BR&gt;



Current Output Format: !!!PAN:XXXX,TLT:YYYY Where XXXX is pan servo micro seconds from 0000 to 3000 and YYYY is tilt server milliseconds from 0000 to 3000. These fields are fixed length at 4 characters.

Sample Source Code for this output mode can be found in the <a href='http://code.google.com/p/happykillmore-gcs/downloads/detail?name=ArduTracker%20v1.zip&can=2&q='>ArduTracker</a> source for the original ArduPilot.

&lt;BR&gt;



&lt;BR&gt;

Hardware: http://www.sparkfun.com/products/8785 (or any Arduino based platform)

**Heading** - Sends angle settings from pan and tilt servos ranging from 0.0 to 359.0 for pan and -180.0 to 180.0 for tilt. All calibration and end-point adjustments have to be handled on the tracker's microcontroller. The assumption is that 1 degree of output equals 1 degree of movement on the tracker. The Tracker Offset can still be used on the GCS or can be set to 0 and handled in the tracker's logic.

&lt;BR&gt;



&lt;BR&gt;



Current Output Format: !!!HED:X.X,ANG:Y.X+++ Where XXX.X is heading with one decimal place and YY.Y is tilt angle. These fields are not fixed length and may contain a negative for tilt.

&lt;BR&gt;



&lt;BR&gt;

Hardware: None currently - Homebrew

**LatLong** - Sends ArduPilot Legacy commands including LAT, LON, ALT and requires all math functions to be completed on tracker. GCS does not perform any math relating to home and current plane location. All end-point adjustment, calibration and set home routines must be handled by the tracker. 

&lt;BR&gt;



&lt;BR&gt;


Current Output Format: !!!LAT:XXXX.XXXXXX,LON:YYYYY.YYYYYY,ALT:Z.Z Where X is Latitude, Y is Longitude and Z is Altitude. These fields are not fixed length. ALT will vary based on the selection of Altitude offset in the settings form. Either from sea level or from home location. 

&lt;BR&gt;



&lt;BR&gt;

Hardware: None currently - Homebrew

**ArduStation** - Sends all required variables to the ArduStation. This makes it possible to use the ArduStation with other GPS or Auto-pilot input sources.

Current Output Format: !!!LAT:A,LON:B,ALT:C,ALH:D,CRS:E,BER:F,SPD:G,WPN:H,DST:I,BTV:J.JJ,SAT:K,LOC:L
+++ASP:M,RLL:N,PCH:O,THH:P,CRS:E

&lt;BR&gt;



&lt;BR&gt;

Hardware: http://store.diydrones.com/ArduStation_p/de-0001-01.htm

**Melih Servo Driver** - Uses Melih's custom protocol found here: http://www.diydrones.com/profiles/blogs/new-circuit-for-antenna

Current Output Format: CommandSet: [Number](Servo.md)+[position\_us](position_us.md)+[13](chr.md)  

&lt;BR&gt;



&lt;BR&gt;


Hardware: http://store.flytron.com/rc-electronics/94-6ch-rs232-servo-driver.html

**Pololu Servo Driver Protocol** - Uses Command #4 for raw data output. Servo ID number can be selected in the calibration form for pan and tilt as well as calibration.

Hardware: http://www.pololu.com/catalog/category/12

**MiniSSC II** - Pololu Servo drivers can speak this language too (jumper selection)

Hardware: http://www.rentron.com/PicBasic/Mini_SSC_II.htm

**Maestro Protocol (Pololu)** -
Download the Maestro Software http://www.pololu.com/docs/0J40/3.a

  1. Launch the Maestro Control Center with your Pololu board connected (and the GCS turned off)
  1. Serial settings tab, select USD Dual Port and press Apply Settings.
  1. Make note of the device number (12 by default), this will be used on the calibration window of the GCS.
  1. Channel Settings tab you may want to change the min value to 0 and the max value to 3000 for channels 0 and 1. They can be limited using the calibration window in the GCS but failing to set these values in the Maestro Control Center will physically disallow the servos to move outside of the 1000-2000 range in the GCS.
  1. Channel Settings tab set speed to 1000 and acceleration to 255 for channels 0 and 1.
  1. Apply Settings
  1. Launch GCS and select Maestro Protocol, Select Command Port (not TTL in device manager), Baud rate can be set to anything (will auto detect baud rate).

Hardware: http://www.pololu.com/catalog/category/12


---

## Calibration ##
After selecting PanTilt for Output Type on the Tracking tab and clicking Connect, a button labelled "Calibrate" will appear at the bottom left.

![http://www.happykillmore.com/software/hk_gcs/TrackingCalibration.gif](http://www.happykillmore.com/software/hk_gcs/TrackingCalibration.gif)

The purpose of this screen is to tweak the end-points of the servo's movement and to specify what angle those endpoints represent.

**WARNING:** You can DAMAGE your servo using this tool! Please be VERY careful to make small adjustments towards the far left and far right of the slider!

Start with the top slider labelled "Left" under Pan end-point calibration. Move the slider to the left and make sure that the servo pans left. If it's backwards, then slide the slider to the right to make the servo go left. Listen to your servos. As you get close to the end of your servo's travel abilities, the servo will start to make a straining sound and will stop moving. Once you have found this point, back off slightly. Now, you'll need to set the angle for this deflection. Many servos will only travel 90 degrees left and 90 degrees right. If you have a servo that can travel a greater distance, then you can specify a larger angle value. You may want to use a protractor to determine the actual angle.

![http://www.dynapod.com/protractor2.jpg](http://www.dynapod.com/protractor2.jpg)

Repeat these instructions for Left, right, up and down. The angle values are important as the combination of end-points and angles are what the GCS uses to point the antenna at your plane. It is also recommended that you specify a down angle less than 0 if your equipment can physically handle it. In some cases, if you're using "Side and Back Lobe" (see below), your antenna may need to point at the ground at a heading 180 degrees off to get the best signal.


---

## Tracking - Offset ##
On the tracking tab is a value labelled "Offset" this is used to tell the system what direction your antenna tracker is pointed when at the "0" heading. For example, if your antenna tracker is pointed due East the you would select "90" in the offset value. Use a compass to determine your heading. It is VERY important to set this value before trying to fly. Without specifying an offset, the GCS will assume your antenna tracker is pointed due North and this can cause for some serious problems.

![http://www.happykillmore.com/software/hk_gcs/TrackingTab.gif](http://www.happykillmore.com/software/hk_gcs/TrackingTab.gif)


---

## Use side & back lobes when flying behind antenna ##
This option is located on the calibration form and may help overcome limitations in your pan servo travel. If you plan on flying 360 degrees around your tracker then I strongly suggest designing a geared solution or purchasing special servos that can allow for full 360 degree rotation. If you do not plan on flying behind your antenna tracker, then I would suggest selecting "Use side & back lobes when flying behind antenna" just in case. Here's how it works.

Every patch antenna has a main lobe, 2 side lobes and a back lobe. The intent of the antenna tracker is to keep the main lobe pointed towards the plane at all times. This will give the clearest signal and the best range. If your antenna tracker only gets 90 degrees of rotation to the left and the right, then you only have 180 degrees covered. In this case, without "Use side & back lobes when flying behind antenna" selected, the tracker will simply turn all the way left to the end-point and stay there until the plane gets closer to the right side and then the tracker will rotate all the way right. This will probably result in lost signal for a portion of the time the plane is behind the antenna.

![http://www.happykillmore.com/software/hk_gcs/Lobes.gif](http://www.happykillmore.com/software/hk_gcs/Lobes.gif)

Looking at the diagram above (this is a top-down view of a patch antenna's coverage area), you can see that there are two fairly good sized side lobes that can be used while the plane is behind the antenna. By selecting "Use side & back lobes when flying behind antenna" as soon as the plane passes 90 degrees left, the antenna will rotate 90 degrees right in an attempt to place the plane in the left side lobe. It will try to follow the plane and keep it in the left lobe until it reaches the left end-point, at which time it will rotate to the right side lobe and continue rotating until the plane can be reached by the main lobe again.

In some cases, the servos will not allow for 180 degrees of travel and in this worst-case-scenario, the GCS will try to use the tiny back lobes when the plane is near 180 degrees off the tracker's 0 degree mark. In this situation, the antenna will point directly away from the plane and tilt down towards the ground in an attempt to best line up the back lobe with the plane. The range is very small on the back lobes so this is not a good way to fly. Having at least 180 degrees of coverage on your pan servo will eliminate the back lobe attempt.