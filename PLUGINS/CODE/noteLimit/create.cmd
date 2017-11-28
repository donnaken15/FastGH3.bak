cd C:\Windows\FastGH3\PLUGINS\CODE\notelimit
C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe "notelimitfix.vcxproj" /p:Configure=Release /t:Rebuild
copy notelimitfix.dll C:\Windows\FastGH3\PLUGINS\notelimitfix.dll
del notelimitfix.pdb
del notelimitfix.iobj
del notelimitfix.ipdb
del notelimitfix.ilk
pause