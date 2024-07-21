# This is not intended to be an executable script.
# Rather, this is a condensed straightforward version of the Arch wiki for a typical installation.
# You will need to verify every step does contribute to your end goals.

# Esto no pretende ser un script ejecutable.
# Más bien, esta es una versión sencilla condensada del Arch wiki para una instalación típica.
# Deberá verificar que cada paso contribuya a sus objetivos finales.

# Only if you wish to change keyboard layouts (default is US).
# Solo si desea cambiar la distribución del teclado (el valor predeterminado es EE. UU.).
ls /usr/share/kbd/keymaps/**/*.map.gz
loadkeys FILEARCHIVO

# Verify you're in the boot mode you intend to use. If this displays the directory without error, you're in UEFI.
# Verifique que esté en el modo de arranque que desea usar. Si esto muestra el directorio sin errores, está en UEFI.
ls /sys/firmware/efi/efivars

# You must have internet to install. For a fast installation, connect an ethernet cable and skip the next seven lines. Optionally, enable internet after installation at the bottom.
# Debe tener internet para instalar. Para una instalación rápida, conecte un cable ethernet y omita las siguientes siete líneas. Opcionalmente, habilite Internet después de la instalación en la parte inferior.
ip link
iwctl
device list
station DEVICEAPARATO scan
station DEVICEAPARATO get-networks
station DEVICEAPARATO connect SSID
quit

timedatectl status
timedatectl list-timezones
timedatectl set-timezone VALUEVALOR

# The default start and stop sectors are usually very accurate. If you need a specific disk size, use the unit displayed in the summary to calculate how many sectors you need. Here's an example assuming a unit of 512 bytes:
# Los sectores de inicio y parada predeterminados suelen ser muy precisos. Si necesita un tamaño de disco específico, use la unidad que se muestra en el resumen para calcular cuántos sectores necesita. Aquí hay un ejemplo asumiendo una unidad de 512 bytes:
# 1GB = 1,953,125
# 2GB = 3,906,250
# 3GB = 5,859,375
# 5GB = 9,765,625
# 10GB = 19,531,250
fdisk -l
fdisk /dev/DISKDISCO
d # Delete Borrar
n # New Nuevo

mkfs.fat -F 32 /dev/EFI
mkfs.ext4 /dev/ROOT
mkswap /dev/SWAP

mount --mkdir /dev/EFI /mnt/boot
mount /dev/ROOT /mnt
swapon /dev/SWAP

# Optionally, include additional packages and groups to install
# Opcionalmente, incluya paquetes y grupos adicionales para instalar
pacstrap -K /mnt base linux linux-firmware # base-devel iwd dhcpcd nano acpi
genfstab -U /mnt >> /mnt/etc/fstab
arch-chroot /mnt

ln -sf /usr/share/zoneinfo/REGIONREGIÓN/CITYCIUDAD /etc/localtime
hwclock --systohc

# Edit /etc/locale.gen and uncomment en_US.UTF-8 UTF-8 and other needed locales
# Edite /etc/locale.gen y descomente en_US.UTF-8 UTF-8 y otras configuraciones regionales necesarias
locale-gen
echo LANG=en_US.UTF-8 > /etc/locale.conf

# Only if you changed the keyboard layout
# Solo si cambió la disposición del teclado
echo KEYMAP=MAPMAPA > /etc/vconsole.conf

echo HOST > /etc/hostname
touch /etc/hosts
# Edit to add:
# Editar para agregar:
# 127.0.0.1	localhost
# ::1		    localhost
# 127.0.1.1	HOST

passwd

# FOR UEFI SYSTEMS
# PARA SISTEMAS UEFI
pacman -S grub efibootmgr
mkdir /boot/efi
mount /dev/EFI /boot/efi
grub-install --target=x86_64-efi --bootloader-id=GRUB --efi-directory=/boot/efi
grub-mkconfig -o /boot/grub/grub.cfg

# FOR OTHER SYSTEMS
# PARA OTROS SISTEMAS
pacman -S grub
grub-install /dev/EFI
grub-mkconfig -o /boot/grub/grub.cfg

pacman -S sudo
useradd -m USERUSUARIO
passwd USERUSUARIO
usermod -aG wheel,audio,video,storage USERUSUARIO

# The default editor for visudo is Vi. You may skip the references to nano if you prefer to keep it. In any case, uncomment %wheel ALL=(ALL:ALL) ALL
# El editor predeterminado para visudo es Vi. Puede omitir las referencias a nano si prefiere conservarla. En cualquier caso, descomente %wheel ALL=(ALL:ALL) ALL
pacman -S nano
EDITOR=nano visudo

exit
reboot

# If you did not install additional packages, you'll need to manually enable internet after rebooting, starting with ethernet.
# Si no instaló paquetes adicionales, deberá habilitar el internet manualmente después de reiniciar, empezando con ethernet.
networkctl list
nano /etc/systemd/network/20-wired.network
# [Match]
# Name=DEVICEAPARATO
# [Network]
# DHCP=yes
sudo systemctl restart systemd-networked.service

# Stop here if you don't want wifi.
# Detente aquí si no quieres wifi.
sudo pacman -S iwd
sudo systemctl enable iwd.service
sudo systemctl start iwd.service
iwctl
device list
station DEVICEAPARATO scan
station DEVICEAPARATO get-networks
station DEVICEAPARATO connect SSID
quit
sudo nano /etc/iwd/main.conf
# [General]
# EnableNetworkConfiguration]=true
sudo pacman -S dhcpcd
sudo systemctl enable dhcpcd
sudo systemctl start dhcpcd
