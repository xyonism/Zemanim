#!/usr/bin/env pwsh
<#
Generate an Android JKS keystore for signing the app.

Usage: Run from the project folder or double-click in File Explorer in Windows PowerShell.
Requires: keytool (part of JDK) in PATH.
#>

param(
	[string]$KeystorePath = "./my-release-key.jks",
	[string]$StorePass = "ChangeThisStorePassword",
	[string]$KeyPass = "ChangeThisKeyPassword",
	[string]$Alias = "mykey",
	[string]$DName = "CN=Dev, OU=Dev, O=Dev, L=City, S=State, C=US",
	[int]$ValidityDays = 10000
)

function Ensure-Keytool {
	$kt = Get-Command keytool -ErrorAction SilentlyContinue
	if (-not $kt) {
		Write-Error "keytool not found. Install a JDK and ensure keytool is on PATH."
		exit 2
	}
}

Ensure-Keytool

$keystoreFull = Resolve-Path -LiteralPath $KeystorePath -ErrorAction SilentlyContinue
if ($keystoreFull) {
	Write-Host "Keystore already exists at: $keystoreFull" -ForegroundColor Yellow
	exit 0
}

Write-Host "Generating keystore at: $KeystorePath"


# Use JKS store type to allow separate key passwords and avoid PKCS12 behavior where -keypass may be ignored
$args = @(
	'-genkeypair',
	'-v',
	'-keystore', $KeystorePath,
	'-storetype', 'JKS',
	'-storepass', $StorePass,
	'-keypass', $KeyPass,
	'-alias', $Alias,
	'-keyalg', 'RSA',
	'-keysize', '2048',
	'-validity', $ValidityDays,
	'-dname', $DName
)

& keytool @args

if ($LASTEXITCODE -ne 0) {
	Write-Error "keytool failed with exit code $LASTEXITCODE"
	exit $LASTEXITCODE
}

Write-Host "Keystore created: $KeystorePath" -ForegroundColor Green
