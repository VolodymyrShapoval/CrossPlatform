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
    # linux.vm.provision "shell", inline: <<-SHELL
    #   sudo apt-get update
    #   sudo apt-get install -y wget apt-transport-https
    #   wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    #   sudo dpkg -i packages-microsoft-prod.deb
    #   sudo apt-get update
    #   sudo apt-get install -y dotnet-sdk-8.0
    # SHELL
  end

  # # Конфігурація для Windows VM
  # config.vm.define "windows_vm" do |windows|
  #   windows.vm.box = "gusztavvargadr/windows-10"
  #   windows.vm.hostname = "windows-environment"

  #   windows.vm.provision "shell", inline: <<-SHELL
  #     Set-ExecutionPolicy Bypass -Scope Process -Force; `
  #     [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; `
  #     iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
  #     choco install -y dotnet-sdk --version=8.0
  #   SHELL
  # end
end
