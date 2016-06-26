$EpisodeFile_Path = $env:sonarr_episodefile_path
$wshell = New-Object -ComObject Wscript.Shell
$wshell.Popup("$EpisodeFile_Path",0,"Done",0x1)
python "C:\Users\charl\Documents\MP4 Converter\manual.py" -i "$EpisodeFile_Path" -a
