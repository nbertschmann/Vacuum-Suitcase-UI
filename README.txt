# this is a README file

I. Name
--------
UHV Suitcase LSA Application 

II. Purpose
------------
This program is intended to facilitate the reading and collection of data coming from the LSA 
when attached to the UHV suitcase. 

The LSA is a rechargeable battery-powered controller for ion pumps with built-in pressure conversion

III. Description
----------------
The program displays the temperature and pressure from inside the suitcase. It also displays the 
battery level reading and pump current from the LSA itself. The program includes two graphs - 
temperature vs. time and pressure vs. time, which display in live time the internal conditions 
of the UHV suitcase. The user is able to specify the length of time of measurement and how often
the measurements are to be made. The data read by this program can then be saved in .csv format 
for further analysis. 

IV. Syntax
-----------

	a) _variableName: for variables related to timing - TimeSpan and DateTime types only
	b) variableName: for variables of other types than described in a)
	c) ClassName: all class names are in this format
	d) MethodName: all method names are in this format
	e) buttonName_action: all event names are in this format

V. File list
-------------
DataPoint.cs                 Reads relevant data from LSA and stores
Form1.cs                     Main form of application; data is displayed and other forms can be accessed
Form1.Designer.cs	     Design specificatioms of Form1 (main UI) form
FormAbort.cs                 Allows user to take next steps after indicating that they would like to stop reading data
FormAbort.Designer.cs        Design specifications of FormAbort form
FormSaveData.cs              Allows user to save data that has been collected
FormSaveData.Designer.cs     Design specifications of FormSaveData form
FormTimeInput.cs	     Allows user to input timing preferences for data collection
FormTimeInputDesigner.cs     Design specifications of FormTimeInput form
README.txt 	             This file
Program.cs

VI. Documentation
------------------
Full documentation available upon request

VII. Technologies
-----------------
Project was created with
*Visual Studio 2019
*C#
*Windows Presentation Foundation (WPF) UI framework
