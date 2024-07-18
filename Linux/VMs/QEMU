clear && \
cd ~ && \
rm -rf QEMU && \
rm -rf ARCH && \
negd QEMU https://download.qemu.org/qemu-8.2.1.tar.xz && \
negd ARCH https://mirrors.edge.kernel.org/archlinux/iso/2024.02.01/archlinux-2024.02.01-x86_64.iso && \
cdgd ~/QEMU && \
curl -fsSL $QEMU -o qemu.tar.xz && \
tar xJf qemu.tar.xz && \
rm qemu.tar.xz && \
cd qemu-8.2.1 && \
./configure --enable-slirp && \
make -j && \
npgd "$(pwd)/build" && \
nagd q qemu-system-x86_64 && \
nagd qi qemu-img && \
cdgd ~/ARCH && \
curl -fsSL $ARCH -o arch.iso && \
qi create -f qcow2 blank.img 100G && \
cp blank.img base.img && \
q -m 4G -cdrom arch.iso -boot d -drive file=base.img,format=qcow2 -enable-kvm -nic user,model=virtio-net-pci


7z a -t7z -mx=9 Arch.7z Arch


7z x Arch.7z -o.
q -hda Arch -boot c -nic user,model=virtio-net-pci