# Speech Settings #

  * **Scripting Variables**
    * {wpn} - Waypoint number (0 = Home)
    * {asp} - Air speed
    * {alt} - Current altitude
    * {wpa} - Desired waypoint altitude
    * {gsp} - Ground speed
    * {mode} - Current mode
    * {alarm} - Alarm Timeout
    * (warning} - Warning Timeout
    * (sats} - Satellite Count

  * Announce on Waypoint will fire any time the waypoint number changes. In the case where waypoint number is 0, the word "home" will be substituded.
  * Sample phrase: Arrived at waypoint {wpn} at {gsp} miles per hour. Current altitude is {alt}, desired alt is {wpa}.
  * Announce on Mode Change will fire any time the auto-pilot's mode changes.
  * Announce Link Warning will fire after the Warning Timeout period has expired and no new messages have arrived.
  * Announce Link Alarm will fire after the Alarm Timeout period has expired and no new messages have arrived.

  * Additional voices can be downloaded here:

http://www.microsoft.com/download/en/details.aspx?id=10121 (Download and run SpeechSDK51MSM.exe)