---
description: Quick reference guide with essential Ubuntu Server CLI commands for system management, file handling, package management, and user administration.
---

# Ubuntu Server CLI Cheat Sheet

## System Information and Management

- **`uname -a`**: Displays all system information.
- **`hostnamectl`**: Shows current hostname and related details.
- **`lscpu`**: Lists CPU architecture information.
- **`timedatectl status`**: Shows system time and timezone information.

### System Monitoring and Management

- **`top`**: Displays real-time system processes.
- **`htop`**: Interactive process viewer (needs installation).
- **`df -h`**: Shows disk usage in a human-readable format.
- **`free -m`**: Displays free and used memory in MB.
- **`kill <process id>`**: Terminates a process.

### Running Commands

- **`[command] &`**: Runs command in the background.
- **`jobs`**: Displays background commands.
- **`fg <command number>`**: Brings a background command to the foreground.

## Service Management

- **`sudo systemctl start <service>`**: Starts a service.
- **`sudo systemctl stop <service>`**: Stops a service.
- **`sudo systemctl status <service>`**: Checks the status of a service.
- **`sudo systemctl reload <service>`**: Reloads a service’s configuration without interrupting its operation.
- **`journalctl -f`**: Follows the journal, showing new log messages in real-time.
- **`journalctl -u <unit_name>`**: Displays logs for a specific systemd unit.

## Cron Jobs and Scheduling

- **`crontab -e`**: Edits cron jobs for the current user.
- **`crontab -l`**: Lists cron jobs for the current user.

## File Management

- **`ls`**: Lists files and directories.
- **`touch <filename>`**: Creates an empty file or updates the last accessed date.
- **`cp <source> <destination>`**: Copies files from source to destination.
- **`mv <source> <destination>`**: Moves or renames files.
- **`rm <filename>`**: Deletes a file.

### Directory Navigation

- **`pwd`**: Displays the current directory path.
- **`cd <directory>`**: Changes the current directory.
- **`mkdir <dirname>`**: Creates a new directory.

### File Permissions and Ownership

- **`chmod [who][+/-][permissions] <file>`**: Changes file permissions.
- **`chmod u+x <file>`**: Makes a file executable by its owner.
- **`chown [user]:[group] <file>`**: Changes file owner and group.

## Searching and Finding Files

- **`find [directory] -name <search_pattern>`**: Finds files and directories.
- **`grep <search_pattern> <file>`**: Searches for a pattern in files.

## Archiving and Compression

- **`tar -czvf <name.tar.gz> [files]`**: Compresses files into a tar.gz archive.
- **`tar -xvf <name.tar.[gz|bz|xz]> [destination]`**: Extracts a compressed tar archive.

## Text Editing and Processing

- **`nano [file]`**: Opens a file in the Nano text editor.
- **`cat <file>`**: Displays the contents of a file.
- **`less <file>`**: Displays the paginated content of a file.
- **`head <file>`**: Shows the first few lines of a file.
- **`tail <file>`**: Shows the last few lines of a file.
- **`awk ‘{print}’ [file]`**: Prints every line in a file.

## Package Management (APT and Snap)

### APT

- **`sudo apt install <package>`**: Installs a package.
- **`sudo apt install -f --reinstall <package>`**: Reinstalls a broken package.
- **`apt search <package>`**: Searches for APT packages.
- **`apt-cache policy <package>`**: Lists available package versions.
- **`sudo apt update`**: Updates package lists.
- **`sudo apt upgrade`**: Upgrades all upgradable packages.
- **`sudo apt remove <package>`**: Removes a package.
- **`sudo apt purge <package>`**: Removes a package and all its configuration files.

### Snap

- **`snap find <package>`**: Searches for Snap packages.
- **`sudo snap install <snap_name>`**: Installs a Snap package.
- **`sudo snap remove <snap_name>`**: Removes a Snap package.
- **`sudo snap refresh`**: Updates all installed Snap packages.
- **`snap list`**: Lists all installed Snap packages.
- **`snap info <snap_name>`**: Displays information about a Snap package.

## User and Group Management

### User Management

- **`w`**: Shows which users are logged in.
- **`sudo adduser <username>`**: Creates a new user.
- **`sudo deluser <username>`**: Deletes a user.
- **`sudo passwd <username>`**: Sets or changes the password for a user.
- **`su <username>`**: Switches user.
- **`sudo passwd -l <username>`**: Locks a user account.
- **`sudo passwd -u <username>`**: Unlocks a user password.
- **`sudo chage <username>`**: Sets user password expiration date.

### Group Management

- **`id [username]`**: Displays user and group IDs.
- **`groups [username]`**: Shows the groups a user belongs to.
- **`sudo addgroup <groupname>`**: Creates a new group.
- **`sudo delgroup <groupname>`**: Deletes a group.

## Networking

### General Networking

- **`ip addr show`**: Displays network interfaces and IP addresses.
- **`ip -s link`**: Shows network statistics.
- **`ss -l`**: Shows listening sockets.
- **`ping <host>`**: Pings a host and outputs results.

### Netplan Configuration

- **`cat /etc/netplan/*.yaml`**: Displays the current Netplan configuration.
- **`sudo netplan try`**: Tests a new configuration for a set period of time.
- **`sudo netplan apply`**: Applies the current Netplan configuration.

### Firewall Management

- **`sudo ufw status`**: Displays the status of the firewall.
- **`sudo ufw enable`**: Enables the firewall.
- **`sudo ufw disable`**: Disables the firewall.
- **`sudo ufw allow <port/service>`**: Allows traffic on a specific port or service.
- **`sudo ufw deny <port/service>`**: Denies traffic on a specific port or service.
- **`sudo ufw delete allow/deny <port/service>`**: Deletes an existing rule.

### SSH and Remote Access

- **`ssh <user@host>`**: Connects to a remote host via SSH.
- **`scp <source> <user@host>:<destination>`**: Securely copies files between hosts.
