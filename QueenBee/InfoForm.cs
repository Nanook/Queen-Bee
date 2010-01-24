using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nanook.QueenBee
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            #region About
            txtAbout.Rtf = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033\deflangfe1033{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}{\f1\froman\fprq2\fcharset2 Symbol;}}
{\*\generator Msftedit 5.41.15.1515;}\viewkind4\uc1\pard\lang2057\b\f0\fs16 Queen Bee is a PAK / QB Explorer, Editor.\b0\par
\par
Please read the information on these tabs.  Coders hate documenting so if they take the time to write something the least you can do is read it  ;-)\par
\par
This application will help everyone discover lots of great hacks.  See the text file included with this release for some areas of interest (after only half an hour of casually browsing).\par
\par
\par
\b Quick Feature List:-\b0\par
\pard\fi-360\li720\lang1024\f1\'b7\tab\lang2057\f0 Supports Wii / PS2 / PC / XBox files.\par
\lang1024\f1\'b7\tab\lang2057\f0 Edits a PAK's QB file in memory (No Import / Export required).\par
\lang1024\f1\'b7\tab\lang2057\f0 Import / Export / Export All functionality for PAK files.\par
\lang1024\f1\'b7\tab\lang2057\f0 Create New / Add / Rename / Remove files in PAK files.\par
\lang1024\f1\'b7\tab\lang2057\f0 Supports all internal QB structures contained in Guitar Hero 3 / Aerosmith / World Tour / Metallica / Smash Hits / Greatest Hits / Tony Hawk's Proving Ground and Downhill Jam.\par
\lang1024\f1\'b7\tab\lang2057\f0 QB structure and array items can be created, removed, copied and pasted.\par
\lang1024\f1\'b7\tab\lang2057\f0 All items are editable including increasing the size of text and script items.\par
\lang1024\f1\'b7\tab\lang2057\f0 Array items can be saved to text files for easy editing.\par
\lang1024\f1\'b7\tab\lang2057\f0 Debug files are supported to help describe the QB file structures.\par
\lang1024\f1\'b7\tab\lang2057\f0 QB files are Bit perfect if loaded and saved without changes even though the file has been broken down and fully rebuilt.\par
\lang1024\f1\'b7\tab\lang2057\f0 Saves and Restores settings.\par
\lang1024\f1\'b7\tab\lang2057\f0 Search Facility (String, QB Key and Numeric).\par
\pard\par
 \par
\b Wish List:-\par
\pard\fi-360\li720\lang1024\b0\f1\'b7\tab\lang2057\f0 Load QB files without PAK/PAB.\b\par
\lang1024\b0\f1\'b7\tab\lang2057\f0 Seamless Qs support.\b\par
\lang1024\b0\f1\'b7\tab\lang2057\f0 Better support for WPC / XBX files.\b\par
\pard\par
\par
Technical Notes:-\b0\par
\pard\fi-360\li720\lang1024\f1\'b7\tab\lang2057\f0 Internal QB pointers are not used when loading files, instead they are used to validate the file is not corrupt.\par
\lang1024\f1\'b7\tab\lang2057\f0 This application was developed to allow other developers to use the code in their code.\par
\lang1024\f1\'b7\tab\lang2057\f0 The code will be released when I'm happy this app functions correctly and all the data types are correct.\par
\pard\par
\par
\b Respect to ALL who contribute to the following:-\par
\pard\fi-360\li720\lang1024\b0\f1\'b7\tab\lang2057\f0 Console Reversing.\par
\lang1024\f1\'b7\tab\lang2057\f0 Homebrew.\par
\lang1024\f1\'b7\tab\lang2057\f0 Scene News.\par
\lang1024\f1\'b7\tab\lang2057\f0 Custom Guitar Hero Discs (Any Console).\par
\pard Your efforts and time are appreciated.\par
\par
\par
Thanks to \b GameZelda\b0  for releasing code for the apps he writes and always being an endless source of technical information.\par
\par
Thanks to the guys behind \b RawkSD\b0  for using the Queen Bee parser and helping making this project worth the effort.\par
\par
}
";
            #endregion
            #region Usage
            txtUsage.Rtf = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033\deflangfe1033{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}{\f1\froman\fprq2\fcharset2 Symbol;}{\f2\fswiss\fprq2\fcharset0 Verdana;}}
{\colortbl ;\red255\green0\blue0;\red0\green0\blue255;\red0\green128\blue0;\red255\green255\blue0;\red75\green0\blue130;\red0\green0\blue139;}
{\*\generator Msftedit 5.41.15.1515;}\viewkind4\uc1\pard\lang2057\f0\fs16 Using this app makes a lot more sense once you know how it works.\par
\par
\par
\b\fs24 Overview\b0\par
\fs16 This is a PAK + QB editor / explorer. It allows you to view and modify the data structures in games by Vicarious Visions for the Wii, PS2, PC and Xbox, although it has not been tested with every game.  The data structures include things like text and values for the menu system and in-game settings.\par
\par
The PAK/PAB is a container for a collection of files.  These files can be audio, video, images, data structures (QB files) etc.  This application can load any PAK/PAB and extract and replace files.  If the contained files are QB files they can be opened for editing.\par
\par
To use this application you will need the PAK, PAB (not for Wii) and optionally a DBG file which are located within the file structure of the game being explored.  The DBG file contains text description of many items in the QB file which makes it invaluable when exploring the data structures.\par
\par
\par
\b\fs24 The QB Key\par
\b0\fs16\par
The QB Key is an important part of QB editing. It is essentially a key that identifies the QB Items in the QB File.  The QB Key links to the text in the DBG file, it can actually be generated from this text.  It is important to remember that its real value is the hex value and not the text.\par
\par
The QB Key can be found playing two roles in a QB File.  Firstly as the 'Item QB Key' that identifies a QB Item and secondly as a 'QB Key' which is a pointer to an 'Item QB Key'.\par
\par
When editing QB Keys you can type in a made up text value if you need to, the hex crc will be created for you and stored in the item.  If the hex crc already exists in the DBG file with a different text string a warning will be displayed, a new string should be entered.\par
\par
Because the text is loaded from the DBG file and the new value will not be saved there; Queen Bee will save it to a file named the as the PAK with a '.UserDbg' extension.\par
\par
\par
\b\fs24 The Interface\par
\b0\fs16 The application has 3 tabs which are described below.\par
\par
\par
\b\i\fs20 1. PAK Tab\par
\b0\i0\fs16\par
\b Loading PAK/PAB Files\par
\b0 Use this tab to select the \ldblquote Format\rdblquote  of the files to be loaded. Clicking the \ldblquote Load\rdblquote  button will display the contents of the PAK in the list on the right hand side.  The \ldblquote Backup\rdblquote  checkbox will make a copy of the PAK/PAB on load, this allows multiple saves to be made to the file without losing the original backup.  When a backup copy is made an existing backup will be overwritten, so always make sure you have a another backup elsewhere.\par
\par
\b PAK/PAB Contents\par
\b0 The contents of the PAK are displayed in the list on the left.\par
\par
Double clicking an item performs the same action as \ldblquote Edit QB File\rdblquote .\par
\par
Right-clicking on an item will display a menu with the following items it:-\par
\par
\pard\fi-360\li720\tx720\lang1024\f1\'b7\tab\lang2057\f0 Replace File\'85\tab - Replace the selected file in the PAK/PAB with a file from disk.\par
\pard\fi-360\li720\lang1024\f1\'b7\tab\lang2057\f0 Extract File...\tab - Extract the selected file from the PAK/PAB and save it to disk.\par
\lang1024\f1\'b7\tab\lang2057\f0 Extract All...\tab - Extract all files from a PAK/PAB to a specified folder.\par
\lang1024\f1\'b7\tab\lang2057\f0 New File...\tab - Create a new file with no types in it. (only the Unknown type).\par
\lang1024\f1\'b7\tab\lang2057\f0 Add File...\tab - Adds a file from the disk as a new PAK item.\par
\lang1024\f1\'b7\tab\lang2057\f0 Rename File...\tab - Rename an entry and modify all the internal QB file IDs.\par
\lang1024\f1\'b7\tab\lang2057\f0 Remove File\tab - Removes a file from the PAK.\par
\lang1024\f1\'b7\tab\lang2057\f0 Edit QB File\tab - Edit the QB file using the QB tab.\par
\lang1024\f1\'b7\tab\lang2057\f0 Test All QB Files\tab - Test that the PAK/PAB and all QB files are valid, this tests pointers etc.\par
\pard\par
Columns can be sorted by clicking the column header.  Columns can also be reordered by dragging them in to the desired position.\par
\par
\b Viewing Queen Bee Info\b0\par
Clicking the \ldblquote Info\'85\rdblquote  button opens this window.\par
\par
\par
\b\i\fs20 2. QB Item Search Tab\par
\b0\i0\fs16\par
This tab contains two case insensitive search boxes:\par
\par
\b String Search\b0\par
Enter a string to search for in the text box. This search searches all string data types as well as string that have been found in scripts.  See the Script Editor help section for more information on script strings.\par
\par
\b QB Item Search\b0\par
This search searches for QB Keys. It searches both Item QB Keys as well as QB Key pointers.  The QB Key can be entered as a partial text that will search the debug names or as an hex value that will search the CRCs.\par
\par
\b Number Search\b0\par
This search searches for for a numeric value.  Integer and float types are searched.  If the input text contains a decimal point then only floats are searched.\par
\par
\b Search Results\par
\b0 Double clicking a search result will open the selected item for editing in the \ldblquote QB File\rdblquote  tab.\par
\par
Right-clicking an item will display a menu with the following filter items on it:-\par
\par
\pard\fi-360\li720\tx720\lang1024\f1\'b7\tab\lang2057\b\i\f0 Filter On\b0\i0\tab\tab - Section title item.\par
\pard\fi-360\li720\lang1024\f1\'b7\tab\lang2057\f0 Item\tab\tab - Removes all results not matching the selected item\par
\lang1024\f1\'b7\tab\lang2057\f0 Qb File Name\tab - Removes all results not from the selected file.\par
\lang1024\f1\'b7\tab\lang2057\f0 Type\tab\tab - Removes all results not matching the selected type.\par
\lang1024\f1\'b7\tab\lang2057\b\i\f0 Filter Out\b0\i0\tab - Section title item.\par
\lang1024\f1\'b7\tab\lang2057\f0 Item\tab\tab - Removes all results matching the selected item\par
\lang1024\f1\'b7\tab\lang2057\f0 Qb File Name\tab - Removes all results from the selected file.\par
\lang1024\f1\'b7\tab\lang2057\f0 Type\tab\tab - Removes all results matching the selected type.\par
\pard\par
Columns can be sorted by clicking the column header.  Columns can also be reordered by dragging them in to the desired position.\par
\par
\par
\b\i\fs20 3. QB File Tab\par
\b0\i0\fs16\par
This tab displays the contents of a QB File. The left side displays the structure of the QB Items, the right side displays the data for a selected QB Item.\par
\par
Right-clicking in to the structure brings up a menu:\par
\pard\fi-360\li720\lang1024\f1\'b7\tab\lang2057\f0 Add Child >\tab - Add a child item to the end of the selected item's children.\par
\lang1024\f1\'b7\tab\lang2057\f0 Insert Sibling >\tab - Insert a new item before the selected item at the same level.\par
\lang1024\f1\'b7\tab\lang2057\f0 Add Sibling >\tab - Adds a new item after the selected item at the same level.\par
\lang1024\f1\'b7\tab\lang2057\f0 Remove\tab\tab - Removes the selected item and all its children.\par
\lang1024\f1\'b7\tab\lang2057\f0 Copy\tab\tab - Copies an item and all children ready for pasting.\par
\lang1024\f1\'b7\tab\lang2057\f0 Paste\tab\tab - Allows a copied item to be pasted as Add Child, Insert Sibling ot Add Sibling (see the rules above).\par
\pard Items created with this menu are saved to the memory instantly. \par
\par
When saving to disk, the structure will be checked to ensure certain rules are not violated.\par
\par
\par
\b Saving Updates\par
\b0 After editing an item, the \ldblquote Update\rdblquote  button should be clicked.  This saves the changes to memory so other items can be edited without losing any changes.  The \ldblquote Save to Disk\rdblquote  button will become enable to indicate there are changes to be saved.  Clicking this button will save the QB File back to the PAK/PAB file.\par
\par
If the files are in \ldblquote Xbox\rdblquote  format a warning will be displayed if the files are PAK or PAB are larger than the originals.\par
\par
\b General String Editing\par
\b0 String can contain place holders for items such as colour changes:\par
\f2\fs14\par
\\c0 : \b default\b0  \line\\c1 : \b white\b0  \line\\c2 :\cf1  \b red\cf0\b0  \line\\c3 :\cf2  \b blue\cf0\b0  \line\\c4 :\cf3  \b green\cf0\b0  \line\\c5 :\cf4  \b yellow\cf0\b0  \line\\c6 :\cf2  \b blue\cf0\b0  \line\\c7 : \cf5\b purple\cf0\b0  \line\\c8 :\cf6  \b dark blue\cf0\b0  \line\\c9 : \b silver\b0\f0\fs16\par
\par
\\n : Line break.\par
\par
\par
\b\i\fs18 QB Item Editors\par
\b0\i0\fs16\par
\b Generic Item Editor\b0\par
This editor lists items in a simple list, each item can display its data in different formats by clicking the data type button to right of it. \par
\par
\b Array Editor\b0\par
Used to display the items contained in simple arrays.  The data type can be changed for all items by using the data type button at the top of the list.\par
\par
To edit an item:-\par
\pard\fi-360\li768 1.\tab Select it.\par
2.\tab Edit it\rquote s value in the text box.\par
3.\tab Press Return/Enter or click the \ldblquote Set\rdblquote  button to update it in the list.\par
\pard\par
Once finished use the update button to commit the values to the QB Item.\par
\par
Right-clicking on the item brings up an menu:\par
\pard\fi-360\li720\lang1024\f1\'b7\tab\lang2057\f0 Insert Item\tab - Inserts a new item before the selected item.\par
\lang1024\f1\'b7\tab\lang2057\f0 Add Item\tab\tab - Adds a new item after the selected item\par
\lang1024\f1\'b7\tab\lang2057\f0 Remove Item\tab - Removes the selected item.\par
\lang1024\f1\'b7\tab\lang2057\f0 Move Up\tab\tab - Moves the selected item up.\par
\lang1024\f1\'b7\tab\lang2057\f0 Move Down\tab - Moves the selected item down.\par
\par
\pard Use the \ldblquote Import\rdblquote  and \ldblquote Export\rdblquote  buttons to load and save arrays as text files. This allows the use of a more powerful editor.\par
\par
When editing items with the menu, the \ldblquote Update\rdblquote  button must be used to save the items.\par
\par
\par
\b Script Editor\b0\par
This editor allows scripts to be viewed / edited.  There are 2 tabs in this editor:\par
\par
\pard\fi-360\li720\tx720 1.\tab\b Strings\b0  \endash  Lists any string that have been identified from the hex (see tab 2)\line\cf1\b Warning:\cf0\b0  When editing these strings ensure that only text you see in the game is changed. Sometimes when these strings are identified, characters are included because they are readable, but are actually part of the binary script. Editing them or changing their position may cause the script to be corrupt and therefore break the game.  The strings are fixed width and the editor will not let you make them longer than the original. If you shorten them they will be padded with spaces.  \b\i Use this feature with care.\b0\i0\par
\pard\par
\pard\fi-360\li720\tx720 2.\tab\b Uncompressed Script\b0  \endash  This tab shows a simple hex dump of the script, the strings from the first tab can be found in this data.  If you wish to edit it you can use the \ldblquote Export\'85\rdblquote  and \ldblquote Import\'85\rdblquote  buttons at the bottom of this control.\b\par
\pard\b0\par
\par
\par
\b\fs24 Queen Bee Files\par
\b0\fs16\par
Queen Bee creates various files in the same folder as the source files (PAK/PAB/DBG):-\par
\par
\pard\fi-360\li720\lang1024\f1\'b7\tab\lang2057\f0 .bak\tab\tab - Created for any files that are backed up on load (PAK/PAB).\par
\lang1024\f1\'b7\tab\lang2057\f0 .decompressed\tab - Created and loaded for editing in XBox format (PAK/PAB/DBG).\par
\lang1024\f1\'b7\tab\lang2057\f0 .UserDbg\tab\tab - Created when custom QB Keys are created using text values.\par
\pard\par
}
";
            #endregion
            #region Version History
            txtVersionHistory.Rtf = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033\deflangfe1033{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}}
{\*\generator Msftedit 5.41.15.1515;}\viewkind4\uc1\pard\lang2057\b\f0\fs24 Version History\b0\fs16\par
\par
\b\fs20 v1.8\b0\fs16\par
 - \b Fixed\b0 : Certain item types were being saved with the wrong ID.\par
 - \b Fixed\b0 : Handle Invalid path exception without crashing.\par
\par
\b\fs20 v1.7\b0\fs16\par
 - \b Added\b0 : Support for GH:WT, GH:M and GH:SH/GH (Not all platforms have been tested)\par
 - \b Added\b0 : Copy and Paste to the Qb Item tree structures. You can also copy and paste over different files.\par
 - \b Added\b0 : Qb Item value to the Qb Item list.\par
 - \b Added\b0 : Number search\par
 - \b Added\b0 : The ability to create new files in the PAK\par
 - \b Added\b0 : The ability to add new files to the PAK\par
 - \b Added\b0 : The ability to rename files in the PAK\par
 - \b Added\b0 : The ability to remove files from files to the PAK\par
 - \b Added\b0 : Ability to import and export array types to text files, for power editing.\par
 - \b Added\b0 : Type to files in PAK list.\par
 - \b Changed\b0 : Qb Item list so it now shows the QbKey when no debug name is found\par
 - \b Changed\b0 : App structure by splitting the core out to a dll (Queen Bee Parser). As used by TheGHOST and RawkSD.\par
 - \b Changed\b0 : The name of StringPointer to QbKeyString\par
 - \b Changed\b0 : The name of StringPointerB to StringPointer\par
 - \b Added\b0 : New QbKeyStringQs types - these point to the qs.pak of strings.  Editing is not supported in Queen Bee, export the related text file, edit and import\par
 - \b Changed\b0 : QbKey search so that entered text can be matched against QbKeys even when no debug file is loaded (full text match only).\par
 - \b Fixed\b0 : Errors when paths are not found when loading / saving scripts etc.\par
 - \b Fixed\b0 : Double \ in debug path when loading pak files from the root of a drive\par
 - \b Changed\b0 : File access to readonly files can be opened without errors.\par
\par
\b\fs20 v1.6\b0\fs16\par
 - \b Changed\b0 : Test All QB files now skips non QB files, rather than stopping with an error.\par
 - \b Fixed\b0 : Entering a QB Key in hex mode will lookup the text value from the debug file.\par
\par
\b\fs20 v1.5\b0\fs16\par
 - \b Changed\b0 : Script editor, pressing Enter/Return on the text box will simulate the Set button being clicked.\par
 - \b Changed\b0 : Script editor now has full exception handling.\par
 - \b Changed\b0 : Calculates QB File ID after file has loaded rather on first request.\par
 - \b Changed\b0 : All formats support optional PAB file (Fixes formats where some PAKs have a PAB and some don't).\par
 - \b Changed\b0 : When loading a PAK/PAB file the top item in the list is selected automatically.\par
 - \b Fixed\b0 : Correctly set tab orders for Array and Script Editors.\par
 - \b Fixed\b0 : PC WPC PAK loading, some PAKS failed.\par
 - \b Fixed\b0 : Added exception handling to XBox Compress / Decompress.\par
\par
\b\fs20 v1.4\b0\fs16\par
 - \b Fixed\b0 : Script length bug (again).\par
\par
\b\fs20 v1.3\b0\fs16\par
 - \b Fixed\b0 : Script length bug.\par
\par
\b\fs20 v1.2\b0\fs16\par
 - \b Changed\b0 : QB items context menu allows Add Child when no item is selected.\par
 - \b Changed\b0 : QB remove item now has extra checking to prevent exceptions.\par
 - \b Changed\b0 : Simple array editor now has full exception handling.\par
 - \b Changed\b0 : Suppressed any exception messages when loading debug (other than when using the 'Load' button on the PAK tab).\par
 - \b Fixed\b0 : Null object bug when searching for QB Key by CRC (Hex).\par
 - \b Fixed\b0 : Scripts are only compressed if they are smaller than the uncompressed version.\par
 - \b Fixed\b0 : Text boxes that accept Return now work on Key Down rather than Key Up.\par
 - \b Fixed\b0 : Custom QB Key name was being wiped from QB item list on update.\par
 - \b Fixed\b0 : QB item editor is cleared if no QB item is selected in the list.\par
\par
\b\fs20 v1.1\b0\fs16\par
 - \b Added\b0 : QB Structure Editing, Right-clicking QB item structure pops up a menu with items for adding and removing items.\par
 - \b Added\b0 : Array Editing, Right-clicking array items pops up a menu with items for adding and removing items.\par
 - \b Added\b0 : Added support for Xbox (xbx) format used in Tony Hawk's Project 8.\par
 - \b Changed\b0 : Array editor, pressing Enter/Return on the text box will simulate the Set button being clicked.\par
 - \b Changed\b0 : QB Keys can now contain '.'.\par
 - \b Changed\b0 : Included '=' in the recognised character set when detecting strings in scripts.\par
 - \b Fixed\b0 : Issue when Updating a type when the Data Type has been switched from string to hex.\par
 - \b Fixed\b0 : Incorrect filename was being shown on exceptions when testing QB file.\par
 - \b Fixed\b0 : Error displaying Calculated and Written length difference had the names transposed.\par
 - \b Fixed\b0 : Stopped the 'You have not saved changes' message box popping when changing tabs if a new QB is been loaded.\par
 - \b Fixed\b0 : Disable the 'Save to File' button when loading a new QB is been loaded.\par
 - \b Fixed\b0 : 00000000 QBKeys are visible editable for items that have them.\par
 - \b Fixed\b0 : Script editor let you update a QB item when QB Key or Unknown was invalid.\par
 - \b Fixed\b0 : Generic Edit Item bug where Data Type button displayed the wrong type name and text was formatted incorrectly.\par
\par
\b\fs20 v1.0\b0\fs16\par
 - \b Added\b0 : Added icon for Midi QB files in PAK list.\par
 - \b Added\b0 : Added support for PC (wpc) format used in Tony Hawk's American Wasteland.\par
 - \b Changed\b0 : Now displays the file extension in Format dropdown list.\par
 - \b Fixed\b0 : PAK file 'Extract...' and 'Replace...' failed when '/' was present in the filename.\par
 - \b Fixed\b0 : Filename not being shown on exceptions when testing QB file.\par
 - \b Fixed\b0 : Issue when Updating a type when the Data Type has been switched from the default in the Generic Editor.\par
\par
\b\fs20 v0.5\b0\fs16\par
 - \b Added\b0 : XBox Support.\par
 - \b Added\b0 : Script Uncompression / Compression.\par
 - \b Added\b0 : Script Editor Panel, displays hex as well as found strings in the script hex.\par
 - \b Added\b0 : String search searches for strings within scripts.\par
 - \b Added\b0 : Search filter context menu. Right-click search results and select an item from the menu.\par
 - \b Added\b0 : Array Editor Panel.\par
 - \b Added\b0 : QB Keys can now be edited using the debug string text or crc.\par
 - \b Added\b0 : New QB key strings are saved to a file named '<pak file>.UserDbg' so they are not lost on reload.\par
 - \b Added\b0 : New QB keys are tested to ensure they do not have the same CRC as an existing debug CRC.\par
 - \b Added\b0 : Ability to search for QB Keys with text as well as hex.\par
 - \b Added\b0 : Hourglass pointer to Load PAK and Searches.\par
 - \b Changed\b0 : Item QB Keys are now editable.\par
 - \b Changed\b0 : Item QB Key now shown at the top of the generic edit list (if present).\par
 - \b Changed\b0 : Integer data types are now displayed as signed int as default.\par
 - \b Changed\b0 : Items that don't have QB Keys no longer have an item displaying '00000000'.\par
 - \b Changed\b0 : Status bar to show PAB info (if available)\par
 - \b Changed\b0 : 'Vector' datatype name to 'Floats'\par
 - \b Changed\b0 : Section, Array and StructItem 'Vector' datatype name to 'FloatsX2'\par
 - \b Changed\b0 : Section, Array and StructItem 'Vector3d' datatype name to 'FloatsX3'\par
 - \b Changed\b0 : Rewrote internal state loading and saving.\par
 - \b Changed\b0 : Rewrote the help pages. \par
 - \b Fixed\b0 : Flickering bug when moving between QB items.\par
 - \b Fixed\b0 : 'Extract All...' no longer displays a success message when the folder dialog was cancelled.\par
 - \b Fixed\b0 : 'Extract File...' and 'Replace File...' now only save the path to the .config file.\par
\par
\b\fs20 v0.4\b0\fs16\par
 - \b Fixed\b0 : Fixed a couple of bugs with StringW (unicode) strings.\par
 - \b Fixed\b0 : Stopped PAB being loaded when no PAB was selected by user.\par
 - \b Fixed\b0 : Detect reading outside of PAK/PAB file and raise an exception.\par
\par
\b\fs20 v0.3\b0\fs16\par
 - \b Added\b0 : PS2 support\par
 - \b Added\b0 : PC support\par
 - \b Added\b0 : ConfigVersion to config file to help config migration for future updates\par
 - \b Added\b0 : Unicode support for PC (tested) and XBox (untested), Wii uses 8bit chars for the StringW datatype, should support all combinations of machine endian and file endian.\par
 - \b Added\b0 : Icons for different file types within a Pak file .\par
 - \b Changed\b0 : String2 item types to StringW (Wide/Unicode).\par
 - \b Changed\b0 : Version number system to x.x from x.x.x.x.\par
 - \b Changed\b0 : Selecting PAK will try and locate PAB and DBG files in the same folder.\par
\par
\b\fs20 v0.0.0.2\b0\fs16\par
 - \b Added\b0 : Search tab. Search by String or QB Key.\par
 - \b Added\b0 : Save and restore splitter positions.\par
 - \b Added\b0 : Save and restore column widths positions and sort order.\par
 - \b Added\b0 : Prompt when leaving QB tab with un saved items.\par
 - \b Fixed\b0 : Improved performance on PAK load.\par
 - \b Fixed\b0 : Internal form title tweak.\par
 - \b Fixed\b0 : Form size and position save and restore (for maximise).\par
 - \b Fixed\b0 : All QB Keys are displayed and edited as Big Endian (previously the hardware default).\par
 - \b Fixed\b0 : Issue where if item had too many items Windows would run out of handles. Now shows message.\par
 - \b Removed\b0 : 'Open QB >>' button from first tab.\par
\par
\b\fs20 v0.0.0.1\b0\fs16\par
 - First Release.\par
\par
}
";
            #endregion
        }

    }
}
