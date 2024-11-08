Vagrant.configure("2") do |config|
  # Конфігурація для Linux VM
  config.vm.define "linux_vm" do |linux|
    linux.vm.box = "hashicorp/bionic64"
    linux.vm.hostname = "linux-environment"
    linux.vm.network "public_network"

    linux.vm.provider "virtualbox" do |vb|
      vb.memory = "2048"
      vb.cpus = 2
    end
    linux.vm.provision "shell", inline: <<-SHELL
      sudo apt-get update
      sudo apt-get install -y wget apt-transport-https
      wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
      sudo dpkg -i packages-microsoft-prod.deb
      sudo apt-get update
      sudo apt-get install -y dotnet-sdk-8.0
    SHELL
  end

  # Конфігурація для Windows VM
  config.vm.define "windows_vm" do |windows|
    windows.vm.box = "gusztavvargadr/windows-10"
    windows.vm.hostname = "windows-environment"

    windows.vm.provision "shell", inline: <<-SHELL
      Set-ExecutionPolicy Bypass -Scope Process -Force
      [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.SecurityProtocolType]::Tls12
      Invoke-WebRequest -Uri "https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-8.0.100-windows-x64-installer" -OutFile "dotnet-sdk-8.0-installer.exe"
      Start-Process "dotnet-sdk-8.0-installer.exe" -ArgumentList "/quiet", "/norestart" -Wait
      Remove-Item -Force "dotnet-sdk-8.0-installer.exe"
      dotnet --version
    SHELL
  end
end