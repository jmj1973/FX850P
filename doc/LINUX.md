


### Reference

From the folloing resouce :

https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#register-the-ubuntu-net-backports-package-repository
https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-environment-variables#net-sdk-and-cli-environment-variables



Register the Ubuntu .NET backports package repository

```
sudo add-apt-repository ppa:dotnet/backports
sudo apt update

```


Register the Microsoft package repository

```
# Get OS version info which adds the $ID and $VERSION_ID variables
source /etc/os-release

# Download Microsoft signing key and repository
wget https://packages.microsoft.com/config/$ID/$VERSION_ID/packages-microsoft-prod.deb -O packages-microsoft-prod.deb

# Install Microsoft signing key and repository
sudo dpkg -i packages-microsoft-prod.deb

# Clean up
rm packages-microsoft-prod.deb

# Update packages
sudo apt update

```


Unregister the Ubuntu .NET backports package repository

```
sudo add-apt-repository --remove ppa:dotnet/backports
sudo apt update

```



Install .NET

```
sudo apt install dotnet-sdk-9.0

```


Use APT to update .NET

```
sudo apt update
sudo apt upgrade dotnet-sdk-9.0

```


Uninstall .NET

```
sudo apt-get remove dotnet-sdk-6.0

```


