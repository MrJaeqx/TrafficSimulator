Traffic Simulation SDK V2.3
---------------------------

Missing Pedestrians
-------------------
Please add a Pedestrian class to the Traffic directory.
It's a boring simulation withouth them!

Simulation architecture: Separating the UI from the logic
---------------------------------------------------------
There are many implementations and patterns possible that separate the UI 
from other logic of the program. The TrafficSim application should use the 
pattern that is explained in chapter 13 of Headfirst C#. Please read and 
understand the complete chapter befor modifying any code.

Export images from Adobe Illustrator to PNG
-------------------------------------------
Use 'File->Save for Web & Devices'  to make a PNG image for use in the aplication.

Note: Do NOT use 'File->Export' from Illustrator to create a bitmap for use with 
Visual Studio. It will cause problems scaling the image when rendering it to a control.
Unscaled images will be rendered larger then its actual size. 


------------------------------------------------------------------------------
Changelog v2.3
------------------------------------------------------------------------------
- Added railway intersection
- Added pedestrian sensors to configurations
- Added sensors for railway
- Split cs file with all intersection configurations
------------------------------------------------------------------------------

 