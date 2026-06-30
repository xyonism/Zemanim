This folder contains helper scripts and notes for creating a signing keystore for Android builds.

Steps to create and use the keystore
1. Edit generate-keystore.ps1 and replace the placeholder passwords (ChangeThisStorePassword / ChangeThisKeyPassword) with secure values.
2. Open PowerShell and run (from the signing folder):
   pwsh .\generate-keystore.ps1
   or
   .\generate-keystore.ps1
3. The script will create my-release-key.jks in this folder.
4. Build a Release APK or AAB in Visual Studio: set Configuration to Release and target Android, then Build -> Archive or Publish.
   Alternatively, use the CLI: dotnet build -c Release -f net10.0-android

Security notes
- Do NOT commit the keystore (my-release-key.jks) or secrets to source control. The .gitignore in this folder prevents that.
- For CI, prefer storing passwords in secure variables and pass them via msbuild properties or environment variables.
