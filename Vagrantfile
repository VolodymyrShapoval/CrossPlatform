Vagrant.configure("2") do |config|
  config.vm.box = "base"

  # Налаштування для віртуальної машини Linux
  config.vm.define "linux" do |linux|
    linux.vm.box = "ubuntu/focal64"  # Ubuntu 20.04
    linux.vm.hostname = "linux-vm"  # Ім'я віртуальної машини
    linux.vm.network "private_network", type: "dhcp"  # Мережа (dhcp)
    linux.vm.provision "shell", path: "scripts/linux_provision.sh"
    
    # Налаштування провайдера для Linux
    linux.vm.provider "virtualbox" do |vb|
      vb.memory = "4096"  # Вказуємо 4096 MB ОЗУ (4 GB)
      vb.cpus = 2         # Вказуємо кількість процесорів
    end
  end

  # Налаштування для віртуальної машини MacOS
  config.vm.define "mac" do |mac|
    mac.vm.box = "peru/macos-mojave"  # Образ MacOS (Mojave)
    mac.vm.hostname = "mac-vm"  # Ім'я віртуальної машини
    mac.vm.network "private_network", type: "dhcp"  # Мережа (dhcp)
    mac.vm.provision "shell", path: "scripts/mac_provision.sh"  # Скрипт для налаштування
    
    # Налаштування провайдера для MacOS
    mac.vm.provider "virtualbox" do |vb|
      vb.memory = "4096"  # 4GB ОЗУ
      vb.cpus = 2         # Кількість процесорів
    end
  end

  # Налаштування для віртуальної машини Windows
  config.vm.define "windows" do |windows|
    windows.vm.box = "gusztavvargadr/windows-10"  # Образ Windows 10
    windows.vm.hostname = "windows-vm"  # Ім'я віртуальної машини
    windows.vm.network "private_network", type: "dhcp"  # Мережа (dhcp)
    windows.vm.provision "shell", path: "scripts/windows_provision.ps1"  # Скрипт для налаштування
    
    # Налаштування провайдера для Windows
    windows.vm.provider "virtualbox" do |vb|
      vb.memory = "4096"  # 4GB ОЗУ
      vb.cpus = 2         # Кількість процесорів
    end
  end
end
