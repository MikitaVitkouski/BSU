## Screenshots

![image](https://github.com/user-attachments/assets/26c573bf-db8e-42f0-b87e-2ed91678499b)

## Description

### Hard Mode

This registry file is designed for advanced users who want to fully disable non-essential Windows services and features to maximize performance, reduce background activity, and gain full control over system behavior.

> ⚠️ **Warning:** This is a highly aggressive tweak set. It disables many background services, security features, and automatic updates. Use at your own risk and only if you understand the consequences.

### Key Changes Applied

| Category                | Description                                                                 |
|-------------------------|-----------------------------------------------------------------------------|
| Services Disabled       | Disables dozens of background services: Superfetch, BITS, Hyper-V, Xbox, Sensors, Maps, Spooler, and more |
| Windows Defender        | Fully disabled via group policies and service stop commands                 |
| Windows Update          | Completely disabled and redirected to WSUS offline server                  |
| Visual Effects          | Minimal UI effects for best performance (animations and themes disabled)   |
| Power & Paging          | Disables hibernation, fast startup, and paging file                         |
| Screen Saver            | Turned off to prevent interruptions                                          |
| Firewall                | All firewall profiles (Domain, Private, Public) disabled                     |
| User Account Control    | UAC is disabled (`EnableLUA=0`) for full administrative control             |

### Intended Use Cases

- Gaming or benchmark environments
- Virtual machines and snapshots
- Highly controlled or air-gapped systems
- Performance-critical builds

**Not recommended** for regular home users or enterprise systems without supervision.
