# UVWizard Project Wiki

Welcome to the **UVWizard** project wiki! This add-on for Unity aims to simplify the process of combining multiple materials and textures on a 3D model into a single material with a unified texture atlas. This documentation will guide you through how the project works, its current status, future plans, and how you can contribute.

---

## **Table of Contents**

1. [Introduction](#introduction)
2. [How It Works](#how-it-works)
3. [Roadmap](#roadmap)
4. [Current Status](#current-status)
5. [Documentation](#documentation)
   - [Software Requirements](#software-requirements)
   - [Installation Instructions](#installation-instructions)
   - [Usage Instructions](#usage-instructions)
6. [Contributing](#contributing)
7. [License](#license)

---

## **Introduction**

**UVWizard** is a Unity add-on designed to optimize 3D models by:

- Combining multiple materials into a single material.
- Repacking UVs to correspond with a new texture atlas.
- Merging multiple textures into one texture atlas.

This tool is particularly useful for reducing draw calls and improving performance in games and applications that use complex models with multiple materials.

---

## **How It Works**

The UVWizard script performs the following steps:

1. **Mesh and Material Retrieval**: Accesses the mesh and materials from the selected GameObject.
2. **UV Repacking**: Adjusts the UV coordinates to fit within designated regions of a new texture atlas.
3. **Texture Atlas Creation**: Combines individual textures from each material into a single texture atlas.
4. **Material Creation**: Generates a new material that uses the combined texture atlas.
5. **Application**: Applies the new UVs and material back to the mesh, replacing the original materials.

By automating these steps, UVWizard streamlines the process of optimizing models for better performance.

---

## **Roadmap**

### **Planned Features**

- **Advanced UV Packing Algorithms**: Implement more efficient UV packing techniques to optimize texture space usage.
- **Support for Additional Texture Maps**: Extend functionality to include normal maps, specular maps, and other material properties.
- **Editor Extension**: Develop a custom Unity Editor window for a more user-friendly interface.
- **Runtime Support**: Optimize the script for runtime use, allowing dynamic models to be processed during gameplay.
- **Error Handling and Logging**: Improve feedback and error messages for better troubleshooting.

### **Milestones**

1. **v1.0**: Basic functionality with manual script execution.
2. **v1.1**: Editor window integration for easier use.
3. **v2.0**: Advanced UV packing and support for additional texture maps.
4. **v2.1**: Runtime optimization and enhanced error handling.

---

## **Current Status**

- **Version**: 1.0
- **Implemented Features**:
  - Basic UV repacking using a grid layout.
  - Texture atlas creation using Unity's built-in `PackTextures` method.
  - Generation of a new material with the combined texture.
- **Known Issues**:
  - Limited UV packing efficiency due to simplistic algorithm.
  - Textures must be readable; non-readable textures require manual adjustment.
  - Does not currently support additional texture maps (e.g., normals, metallic).

---

## **Documentation**

### **Software Requirements**

- **Unity Editor**: Version 2022.3.22f1 or higher.
- **Platform**: Compatible with Windows, macOS, and Linux versions of Unity Editor.
- **Dependencies**: No external packages required.

### **Installation Instructions**

#### Using VRChat Creator Companion (VCC)

To install UVWizard into your Unity project using the VRChat Creator Companion (VCC) and community packages, follow these steps:

##### Add the UVWizard Repository to VCC

1. **Open the VCC and Go to Settings**:
   - Launch the VRChat Creator Companion.
   - Click on the Settings icon in the top-right corner.

2. **Verify VCC Version**:
   - Ensure you're using VCC version 2.1.0 or newer (the version is displayed in the top-right corner of the Settings page).
   - If you're not on the latest version, scroll down and click "Check for Updates".

3. **Navigate to the Packages Tab**:
   - In the Settings page, click on the "Packages" tab.

4. **Add Community Repository**:
   - Either click this link: [https://clnelson888.github.io/uv-wizard/](https://clnelson888.github.io/uv-wizard/)
   - **OR** Click the "Add Repository" button.
   - In the input field that appears, enter the URL of the UVWizard repository: https://clnelson888.github.io/uv-wizard/index.json

- Click "Add".

5. **Confirm Repository Addition**:
- A popup will appear showing information about the repository and the packages it contains.
- Review the information to ensure it's correct.
- Click "I Understand, Add Repository" to confirm.

6. **Verify the Repository is Added**:
- The repository will now appear in your list of installed repositories.
- You should see UVWizard listed among the available packages.

##### Add UVWizard Package to Your Project

1. **Navigate to Your Project**:
- In the VCC, go to the "Projects" tab.
- Select the Unity project where you want to install UVWizard.

2. **Install the UVWizard Package**:
- In your project's details page, scroll to the "Packages" section.
- Find UVWizard in the list of available community packages.
- Click the "Add" or "Install" button next to UVWizard.

3. **Wait for Installation to Complete**:
- The VCC will download and install the UVWizard package into your Unity project.
- Once completed, UVWizard will be available in your project's Packages folder.

##### Open Your Project in Unity

1. Launch Unity Hub.
2. Open your project, and you should see the UVWizard script and associated assets imported.

### **Usage Instructions**

1. **Prepare Your Model**:
- Ensure your GameObject has a `MeshFilter` and a `MeshRenderer` component.
- The model should have multiple materials applied.

2. **Attach the UVWizard Script**:
- Select the GameObject in the Unity Editor.
- Click on "Add Component" in the Inspector window.
- Search for `UVWizard` and add it to the GameObject.

3. **Configure the Script** (Optional):
- In the Inspector, you can adjust the `Texture Atlas Size` to your preferred resolution (default is 2048).

4. **Execute the Script**:
- The script can be executed in two ways:
  - **Automatically on Start**: Uncomment or add the `Start()` method in `UVWizard.cs`:
    ```csharp
    private void Start()
    {
        CombineMaterials();
    }
    ```
  - **Manually**: Call `CombineMaterials()` from another script or through a custom editor button.

5. **Verify the Result**:
- After running the script, the GameObject should now have a single material.
- The mesh UVs will be updated to correspond with the new texture atlas.
- Check the `Materials` and `Mesh Renderer` components to confirm the changes.

---

## **Contributing**

Contributions are welcome! Here's how you can help:

### **Reporting Issues**

- Use the [Issues](https://github.com/YourUsername/UVWizard/issues) tab to report bugs or suggest enhancements.
- Provide detailed information, including steps to reproduce the issue and any relevant screenshots.

### **Submitting Pull Requests**

1. **Fork the Repository**:
- Click on the "Fork" button at the top of the repository page.

2. **Create a Feature Branch**:
- In your forked repository, create a new branch for your feature or fix:
  ```bash
  git checkout -b feature/YourFeatureName
  ```

3. **Commit Your Changes**:
- Make your code changes and commit with clear messages:
  ```bash
  git commit -m "Add feature XYZ"
  ```

4. **Push to Your Fork**:
- Push your changes to your forked repository:
  ```bash
  git push origin feature/YourFeatureName
  ```

5. **Open a Pull Request**:
- Navigate to the original repository and click on "New Pull Request."
- Select your feature branch and submit the pull request for review.

### **Coding Guidelines**

- **Follow C# Coding Standards**: Use consistent naming conventions and code formatting.
- **Comment Your Code**: Provide clear comments and XML documentation where appropriate.
- **Test Your Changes**: Ensure that your code works as intended and does not break existing functionality.

---

## **License**

This project is licensed under the [MIT License](LICENSE). You are free to use, modify, and distribute this software, but please provide attribution to the original author.

---

Thank you for your interest in UVWizard! Your contributions and feedback are invaluable. Together, we can improve this tool to help the Unity community optimize their 3D models more efficiently.
