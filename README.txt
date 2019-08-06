# this is a README file

I. Name
--------
LSA Application

II. Purpose
-----------
This program is intended to facilitate the reading and collection of data coming from the LSA 
when attached to the UHV suitcase. 

III. Description
----------------
The program displays the temperature, pressure, of inside the suitcase. It also displays the 
battery level reading and pump current from the LSA itself. The program includes two graphs - 
temperature vs. time and pressure vs. time, which display in live time the internal conditions 
of the UHV suitcase. The user is able to specify the length of time of measurement and how often
the measurements are to be made. The data read by this program can then be saved in .csv format 
for further analysis. 

IV. File list
-------------
DataPoint.cs                 Reads relevant data from LSA and stores
Form1.cs                     Main form of application; data is displayed and other forms can be accessed
Form1.Designer.cs	     Design specificatioms of Form1 form
FormAbort.cs                 Allows user to take next steps after indicating that they would like to stop reading data
FormAbort.Designer.cs        Design specifications of FormAbort form
FormSaveData.cs              Allows user to save data that has been collected
FormSaveData.Designer.cs     Design specifications of FormSaveData form
FormTimeInput.cs	     Allows user to input timing preferences for data collection
FormTimeInputDesigner.cs     Design specifications of FormTimeInput form
README.txt 	             This file
Program.cs

V. Documentation
----------------
Full documentation available at

VI. Technologies
----------------
Project is created with
*Visual Studio 2019