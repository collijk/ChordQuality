# ChordQuality
This is the Chord Quality Code project, worked on by undergraduates managed by Valdimir Chaloupka

Program takes in and analyzes midi files.  It has a display that shows frequency of sounds played throughout
the midi track, that can be read similarly to sheet music.  It breaks these sounds up into bars (or measures)
and below the portion resembling sheet music, the program labels chords that are being 'played' by the track.
It also displays the intervals when there relevant ones, in tempered base notation.
An aim of the program is to create a midi-track display that reads more like sheet music.

To get the program to build / work on the program: 

	Building the program is pretty straightforward but there are some issues you may run into. 
The program should build in visual studio 2013 or 2015, both have free versions you can easily find online.  
To work on the program in visual studio you may need to download Microsoft SDK, which may or may not install 
automatically when you download visual studio.  You need to make sure visual studio is targeting the right 
version of .NET when you try to build the code.  For visual studio 2013 this should be 4.5 and should happen
automatically (if not follow the 2015 instructions, it should be roughly the same).  For visual studio 2015 
this should be 4.5.2.  2015 will automatically target 4.5,so to change it to 4.5.2 google or follow the 
instructions at: https://msdn.microsoft.com/en-us/library/bb398202.aspx .

With those things in mind if you download the files from github, extract them all, and open the visual studio
solution in your version of visual studio it should run.  (The solution file is one of several files labeled 
'ChordQuality'.  Pay attention to the file type).  

	The program offers several functions to manipulate how the track is played and viewed:

1) Printing Layout

Adjusting the Bars/Row has a visible effect on the program, and you can do it manually in the Printing
Layout box, or you can use the scroll bar on the right side of the screen.  This will compress the number of
bars that appear on screen.  Adjusting Rows/Page will not (currently) have a visible effect on the file but it
will change the height of the rows were you to print the document.  There is not a scroll bar adjustment for this,
the vertical scroll bar moves through the piece.  Changing the rel.thick value changes the thickness of the lines
displayed.  The Bars/Page and Page numbers are adjusted by these factors and provide information on how this will print.
Under file there is also a print preview option.

2) Penalties
3) Quality Weights

You can use this tool to adjust the quality Weights of different intervals or chords.  This will effect the 
Quality displayed above each corresponding chord and interval.  For instance, adjusting the M6 Interval weight will
effect the quality of any major 6 interval in the display, written as 6/Capital letter.  The available intervals are 
major/minor thirds, fourths, fifths, and major/minor sixths

4) Tuning

Displays the 'tuning' value of the piece based on the quality, (displayed by the height of the black bars).  
You can turn off the chord and interval labels, and turning off the tuning will also remove the display of the black
bars.

5) Cut

Tool currently in progress, allows rearrangement of the display of the piece so that the user can create 
something that resembles sheet music in a more meaningful way.  You can 'cut' an area of the display by right-clicking
on the boarders of the area you want to cut, which will create markers.  You can remove the markers with the 'reset
markers' tool and once you've placed two markers you can cut out the area between them with the cut tools.  Eventually
this will remove the cut-piece from the original display and reproduce it graphically below, but still play through it 
as a seamless part of the track.  Currently it only reproduces the peice below.  The clear display button will remove 
the reproduced pieces from the lower display.

6) Tracks

Most midi files have more than one track.  This tool provides a list of the tracks in the file, indicates the 
color they appear in the display and provides the option to turn them on/off. 

7) Transpose file

Adjusting the number here will change the key the midi file is displayed in.

8) Playback

Tool to play, pause, stop playing the midi file.  Has an option to change the tempo and volume.

9) File, Markers, Analysis

The file tab gives you the option to load open or save new midi file, print the display of the midi file.  As
mentioned before it has a print preview option.  It also has a midi-to-text option that displays the information in
the midi file as a .txt file, and an 'info' option that gives you the timing, tempo, key signature and time signature
of the midi file, as well as the number of separate tracks in the file, the octaves spanned by the file and the tracks. 
The marker and analysis tools 

Those are the functions offered right now by the Chord Quality Program.  

