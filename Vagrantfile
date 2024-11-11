Vagrant.configure("2") do |config|
  # Вказуємо Linux box (Ubuntu 18.04)
  config.vm.define "linux" do |linux|
    linux.vm.box = "hashicorp/bionic64"
    linux.vm.hostname = "linux-vm"
    linux.vm.network "public_network"

    # Налаштовуємо ресурси віртуальної машини
    linux.vm.provider "virtualbox" do |vb|
      vb.memory = "4096" # Виділяємо 4 ГБ оперативної пам'яті
      vb.cpus = 4        # Виділяємо 4 процесори
  end
  
  # Основний скрипт налаштування для Linux VM
  linux.vm.provision "shell", run: "always", inline: <<-SHELL
      # Оновлення пакетів і встановлення необхідного ПЗ
      sudo apt-get update
      sudo apt-get install -y wget apt-transport-https unzip

      # Встановлення .NET SDK 8.0
      wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
      sudo dpkg -i packages-microsoft-prod.deb
      sudo apt-get update
      sudo apt-get install -y dotnet-sdk-8.0

      # Встановлення .NET Core 3.1 SDK
      sudo apt-get install -y dotnet-sdk-3.1

      # Перевірка встановлених SDK та Runtime
      dotnet --list-sdks
      dotnet --list-runtimes

      # Завантаження та розпакування BaGet
      echo "Setting up BaGet..."
      if [ -d "/home/vagrant/baget" ]; then
          echo "BaGet is already installed"
      else
          wget https://github.com/loic-sharma/BaGet/releases/download/v0.4.0-preview2/BaGet.zip -O BaGet.zip
          unzip BaGet.zip -d /home/vagrant/baget
          rm BaGet.zip
          if [ -d "/home/vagrant/baget" ]; then
              echo "BaGet setup complete"
          else
              echo "Failed to set up BaGet. Exiting..."
              exit 1
          fi
      fi

      # Перевірка, чи працює BaGet
      RESPONSE=$(curl -o /dev/null -s -w "%{http_code}" http://localhost:5000)
      if [ "$RESPONSE" -eq 200 ]; then
          echo "BaGet is already running"
      else
          echo "Starting BaGet"
          cd /home/vagrant/baget
          nohup dotnet BaGet.dll > /dev/null 2>&1 &
          sleep 5
          RESPONSE=$(curl -o /dev/null -s -w "%{http_code}" http://localhost:5000)
          if [ "$RESPONSE" -eq 200 ]; then
              echo "BaGet started successfully"
          else
              echo "Failed to start BaGet. Exiting..."
              exit 1
          fi
      fi

      # Додавання джерела BaGet та збірка проекту Lab4.Source
      cd /vagrant/Lab4.Source
      echo "Configuring BaGet as a NuGet source..."
      dotnet nuget add source http://localhost:5000/v3/index.json -n BaGet
      if dotnet nuget list source | grep -q "BaGet"; then
          echo "BaGet source added successfully"
      else
          echo "Failed to add BaGet as a NuGet source. Exiting..."
          exit 1
      fi

      echo "Building Lab4.Source project..."
      dotnet build
      if [ -f "./bin/Debug/VShapoval.1.0.0.nupkg" ]; then
          echo "Lab4.Source project built successfully"
      else
          echo "Failed to build Lab4.Source project. Exiting..."
          exit 1
      fi

      # Перевірка, чи існує пакет у BaGet
      echo "Checking if package exists in BaGet..."
      PACKAGE_EXISTS=$(curl -s -o /dev/null -w "%{http_code}" http://localhost:5000/v3/registration/vshapoval/1.0.0.json)
      if [ "$PACKAGE_EXISTS" -eq 200 ]; then
          echo "Package already exists in BaGet. Skipping push..."
      else
          echo "Package does not exist. Pushing package to BaGet..."
          dotnet nuget push -s http://localhost:5000/v3/index.json ./bin/Debug/VShapoval.1.0.0.nupkg --skip-duplicate
          if [ $? -eq 0 ]; then
              echo "Package pushed to BaGet successfully"
          else
              echo "Failed to push package to BaGet. Exiting..."
              exit 1
          fi
      fi

      # Встановлення інструмента
      echo "Installing tool VShapoval globally..."
      dotnet tool install VShapoval --version 1.0.0 --tool-path /bin --add-source http://localhost:5000/v3/index.json

      echo "Run 'Lab4' to launch the tool."
    SHELL
  end

  # ----------------------- WINDOWS CONFIGURATION --------------------------------
  config.vm.define "windows" do |windows|
    # Використовуємо коробку Windows 10
    windows.vm.box = "gusztavvargadr/windows-10"
    windows.vm.hostname = "windows-vm"
    windows.vm.network "public_network"

    # Налаштування ресурсів VirtualBox для Windows VM
    windows.vm.provider "virtualbox" do |vb|
        vb.memory = "4096"
        vb.cpus = 4
    end

    # Провізія Windows VM
    windows.vm.provision "shell", run: "always", inline: <<-SHELL
      # Зняття обмежень на виконання скриптів
      Set-ExecutionPolicy Bypass -Scope Process -Force

      # Встановлення Chocolatey
      Write-Host "Installing Chocolatey..."
      try {
          [System.Net.WebClient]::new().DownloadString('https://chocolatey.org/install.ps1') | Invoke-Expression
      } catch {
          Write-Host "Failed to install Chocolatey. Exiting..."
          exit 1
      }

      # Встановлення .NET SDK і Runtime 8.0
      Write-Host "Installing .NET 8.0 SDK and Runtime..."
      choco install dotnet-8.0-sdk -y
      choco install dotnet-8.0-runtime -y
      if (dotnet --version) {
          Write-Host ".NET Core 8 installed successfully."
      } else {
          Write-Host "Failed to install .NET Core 8. Exiting..."
          exit 1
      }

      # Перевірка встановлених SDK та Runtime
      dotnet --list-sdks
      dotnet --list-runtimes

      # Встановлення .NET Core 3.1 SDK
      Write-Host "Installing .NET 3.1 SDK..."
      choco install dotnetcore-sdk -y
      if (dotnet --list-sdks | Select-String "3.1") {
          Write-Host ".NET Core 3.1 SDK installed successfully."
      } else {
          Write-Host "Failed to install .NET Core 3.1 SDK. Exiting..."
          exit 1
      }

      # Завантаження та розпакування BaGet
      Write-Host "Setting up BaGet..."
      if (Test-Path "C:/Users/vagrant/baget") {
          Write-Host "BaGet is already installed."
      } else {
          Invoke-WebRequest -Uri "https://github.com/loic-sharma/BaGet/releases/download/v0.4.0-preview2/BaGet.zip" -OutFile "C:/tmp/BaGet.zip"
          Expand-Archive -Path "C:/tmp/BaGet.zip" -DestinationPath "C:/Users/vagrant/baget" -Force
          Remove-Item "C:/tmp/BaGet.zip"
      }

      # Перевірка роботи BaGet, запуск при необхідності
      Write-Host "Checking BaGet status..."
      $response = Invoke-WebRequest -Uri "http://localhost:5000" -UseBasicParsing
      if ($response.StatusCode -ne 200) {
          Write-Host "Starting BaGet..."
          cd "C:/Users/vagrant/baget"
          start dotnet BaGet.dll
          Start-Sleep -s 5
      }

      # Налаштування BaGet як джерела NuGet
      Write-Host "Configuring BaGet as a NuGet source..."
      cd /vagrant/Lab4.Source
      dotnet nuget add source http://localhost:5000/v3/index.json -n BaGet

      # Побудова проєкту Lab4.Source
      Write-Host "Building Lab4.Source project..."
      dotnet build

      # Перевірка пакета у BaGet і завантаження, якщо він відсутній
      Write-Host "Checking package existence in BaGet..."
      if (-not (Invoke-WebRequest -Uri "http://localhost:5000/v3/registration/vshapoval/1.0.0.json" -UseBasicParsing).StatusCode -eq 200) {
          Write-Host "Pushing package to BaGet..."
          dotnet nuget push -s http://localhost:5000/v3/index.json ./bin/Debug/VShapoval.1.0.0.nupkg --skip-duplicate
      }

      # Встановлення інструмента VShapoval
      Write-Host "Installing tool VShapoval globally..."
      dotnet tool install --global VShapoval --version 1.0.0
    SHELL
  end
end