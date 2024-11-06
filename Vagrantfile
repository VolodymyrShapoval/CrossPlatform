Vagrant.configure("2") do |config|
  config.vm.box = "base"

  # ������������ ��� ��������� ������ Linux
  config.vm.define "linux" do |linux|
    linux.vm.box = "ubuntu/focal64"  # Ubuntu 20.04
    linux.vm.hostname = "linux-vm"  # ��'� ��������� ������
    linux.vm.network "private_network", type: "dhcp"  # ������ (dhcp)
    linux.vm.provision "shell", path: "scripts/linux_provision.sh"
    
    # ������������ ���������� ��� Linux
    linux.vm.provider "virtualbox" do |vb|
      vb.memory = "4096"  # ������� 4096 MB ��� (4 GB)
      vb.cpus = 2         # ������� ������� ���������
    end
  end

  # ������������ ��� ��������� ������ MacOS
  config.vm.define "mac" do |mac|
    mac.vm.box = "peru/macos-mojave"  # ����� MacOS (Mojave)
    mac.vm.hostname = "mac-vm"  # ��'� ��������� ������
    mac.vm.network "private_network", type: "dhcp"  # ������ (dhcp)
    mac.vm.provision "shell", path: "scripts/mac_provision.sh"  # ������ ��� ������������
    
    # ������������ ���������� ��� MacOS
    mac.vm.provider "virtualbox" do |vb|
      vb.memory = "4096"  # 4GB ���
      vb.cpus = 2         # ʳ������ ���������
    end
  end

  # ������������ ��� ��������� ������ Windows
  config.vm.define "windows" do |windows|
    windows.vm.box = "gusztavvargadr/windows-10"  # ����� Windows 10
    windows.vm.hostname = "windows-vm"  # ��'� ��������� ������
    windows.vm.network "private_network", type: "dhcp"  # ������ (dhcp)
    windows.vm.provision "shell", path: "scripts/windows_provision.ps1"  # ������ ��� ������������
    
    # ������������ ���������� ��� Windows
    windows.vm.provider "virtualbox" do |vb|
      vb.memory = "4096"  # 4GB ���
      vb.cpus = 2         # ʳ������ ���������
    end
  end
end
