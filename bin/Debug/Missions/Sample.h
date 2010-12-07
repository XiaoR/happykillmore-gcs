#define WP_RADIUS 30 // What is the minimum distance to reach a waypoint?
#define LOITER_RADIUS 45 	// How close to Loiter?
#define HOLD_CURRENT_ALT 0	// 1 = hold the current altitude, 0 = use the defined altitude to for RTL
#define ALT_TO_HOLD 100

float mission[][5] = {
{CMD_WAYPOINT,0,100,40.1084967,-85.0377846},
{CMD_WAYPOINT,0,100,40.1081931,-85.0352097},
{CMD_WAYPOINT,0,100,40.1072577,-85.0338256},
{CMD_WAYPOINT,0,100,40.1067981,-85.0331283},
{CMD_WAYPOINT,0,100,40.1062812,-85.0374734},
{CMD_WAYPOINT,0,100,40.1074136,-85.0398874},
{CMD_WAYPOINT,0,100,40.1091532,-85.0399411},
};
