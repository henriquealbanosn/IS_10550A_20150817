REM Run as administrator
@echo off
cls
echo Run this script as Administrator
echo The Script requires these files in the current folder:
echo - this script file: builddoc.cmd
echo - xml comments file from Visual Studio project: comments.xml
echo - executable file: WpfApplication.exe
echo - config file 1: MRefBuilder.config
echo - config file 2: sandcastle.config
pause

set input="D:\Labfiles\Lab01\Ex4\Solution\WpfApplication\bin\Debug\WpfApplication.exe"
set pt="C:\Program Files (x86)\Sandcastle\ProductionTools"
set ptrans="C:\Program Files (x86)\Sandcastle\ProductionTransforms"
set ptpres="C:\Program Files (x86)\Sandcastle\Presentation"
set hhc="C:\Program Files (x86)\HTML Help Workshop\hhc.exe"
set sys="C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\System.dll"
set pf="C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\PresentationFramework.dll"
set xaml="C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\System.Xaml.dll"
set pcore="C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\PresentationCore.dll"

REM %pt%\MRefBuilder /?
REM %pt%\BuildAssembler /?

%pt%\MRefBuilder %input% /dep:%sys%,%pf%,%xaml%,%pcore% /out:reflection.org /internal+ /config:MRefBuilder.config

%pt%\XslTransform /xsl:%ptrans%\ApplyVSDocModel.xsl reflection.org /xsl:%ptrans%\AddFriendlyFilenames.xsl /out:reflection.xml

%pt%\XslTransform /xsl:%ptrans%\ReflectionToManifest.xsl reflection.xml /out:manifest.xml

call %ptpres%\Prototype\copyoutput.bat

%pt%\BuildAssembler /config:sandcastle.config manifest.xml

%pt%\XslTransform /xsl:%ptrans%\ReflectionToChmProject.xsl reflection.xml /out:Output\test.hhp

%pt%\XslTransform /xsl:%ptrans%\createvstoc.xsl reflection.xml /out:toc.xml

%pt%\XslTransform /xsl:%ptrans%\TocToChmContents.xsl toc.xml /out:Output\test.hhc

%pt%\XslTransform /xsl:%ptrans%\ReflectionToChmIndex.xsl reflection.xml /out:Output\test.hhk

%hhc% Output\test.hhp

echo Help file (test.chm) is located in the Output folder
