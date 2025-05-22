# 🕰️ ChronoRoom – The Bernard Effect

**ChronoRoom – The Bernard Effect** is a VR experience built with Unity where the player can control time. The user can toggle a *global freeze* effect that pauses both physics-based and animated objects, creating dramatic and strategic gameplay moments. Designed for immersive interaction using XR Interaction Toolkit.

---

## 🎮 Features

- ⏯️ **Global Time Freeze/Unfreeze** toggle
- 🧱 Works with:
  - **Physics-driven** objects using Rigidbody
  - **Scripted floating** objects using sine/cosine-based motion
- 🧩 Modular architecture:
  - `FreezeAwareObject.cs` for physics objects
  - `FreezeAwareObject_Floating.cs` for floating motion objects
- 🖱️ Simple integration via `PhysicalButtons.cs`
- ⚙️ Time control using Unity’s `Time.timeScale` + custom scripts
- 🧠 Conceptual reference to *time bending environments*

---

## 🧪 Requirements

- Unity **2021.3.34f1 (LTS)**
- **XR Interaction Toolkit v2.5.4**
- Unity Input System (enabled)
- Compatible VR headset for testing (e.g., Meta Quest via Link)

---

## 🔧 Project Structure

```plaintext
Assets/
Scripts/
TimeManager.cs                  # Handles global time freezing/unfreezing
PhysicalButtons.cs             # VR/Physical interaction for toggling time
FreezeAwareObject.cs           # Applies freeze to Rigidbody-based objects
FreezeAwareObject_Floating.cs  # Applies freeze to floating motion objects
FloatingMotion.cs              # Handles sine/cosine motion for hovering objects
