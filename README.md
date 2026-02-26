#                                             📚 StudyBuddy

<div align="center">
  <img src="https://readme-typing-svg.herokuapp.com?font=Fira+Code&pause=1000&color=6366F1&center=true&vCenter=true&width=435&lines=Mobile+Study+Tracker;Cloud+Synchronized;Cross-Platform+App;Built+with+.NET+MAUI+9" alt="Typing SVG" />
</div>

## 💫 About The Project

StudyBuddy is a **cross-platform mobile application** designed to help students track their study sessions with real-time timer functionality and cloud synchronization. Built with **.NET MAUI 9** and **Firebase**, it provides a seamless experience across Android, iOS, and Windows platforms.

**🎯 Perfect for students who want to:**
- ⏱️ Track study time accurately
- 📊 Monitor their study history
- ☁️ Sync data across devices
- 📱 Access their goals anywhere

<div align="center">
  <img src="https://user-images.githubusercontent.com/74038190/212284100-561aa473-3905-4a80-b561-0d28506553ee.gif" width="600">
</div>

---

## 🚀 Download

<div align="center">

[![Download APK](https://img.shields.io/badge/📱_Download-APK_v1.0-brightgreen?style=for-the-badge&logo=android)](https://github.com/ABBAS-PROJECT/StudyBuddy/releases/download/v1.0.0/StudyBuddy-v1.0.apk)

**Requirements:** Android 5.0 or higher

</div>

---
## 📸 Screenshots

<div align="center">

<img src="[screenshots/home.png](https://ibb.co/Dfrrbh5c)" width="250" alt="Home Screen" />
<img src="screenshots/timer.png" width="250" alt="Add goals" />
<img src="screenshots/history.png" width="250" alt="History" />
<img src="screenshots/history.png" width="250" alt="History" />

</div>
---
## ✨ Features

- ⏱️ **Real-Time Stopwatch** - Track study sessions with accurate timing
- ☁️ **Cloud Sync** - Firebase Realtime Database integration
- 📊 **Study History** - View all your past study sessions
- 💡 **Study Tips** - Built-in helpful study advice
- 🎨 **Modern UI** - Clean, intuitive interface
- 📱 **Cross-Platform** - Works on Android, iOS, Windows

<div align="center">
  <img src="https://user-images.githubusercontent.com/74038190/212284115-f47cd8ff-2ffb-4b04-b5bf-4d1c14c0247f.gif" width="600">
</div>

---

## 💻 Tech Stack

### Languages & Frameworks
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![.NET MAUI](https://img.shields.io/badge/.NET_MAUI_9-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![XAML](https://img.shields.io/badge/XAML-0C54C2?style=for-the-badge&logo=xaml&logoColor=white)

### Backend & Database
![Firebase](https://img.shields.io/badge/firebase-%23039BE5.svg?style=for-the-badge&logo=firebase)

### Tools
![Visual Studio](https://img.shields.io/badge/Visual%20Studio_2022-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)
![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)

### Key Technologies
- **Architecture:** MVVM Pattern
- **Navigation:** MAUI Shell with FlyOut Menu
- **Async Programming:** Async/Await with Cancellation Tokens
- **Cloud Integration:** Firebase Realtime Database with CRUD Operations

---

## 📱 Installation

### For Users (Android)
1. Download the APK from [Releases](https://github.com/ABBAS-PROJECT/StudyBuddy/releases)
2. Enable "Install from unknown sources" in Settings → Security
3. Install the APK and start tracking!

### For Developers
```bash
# Clone repository
git clone https://github.com/ABBAS-PROJECT/StudyBuddy.git

# Open in Visual Studio 2022
# Press F5 to run
```

**Prerequisites:**
- Visual Studio 2022 (v17.14+)
- .NET 9 SDK
- .NET MAUI workload installed



---

## 🗂️ Project Structure
```
StudyBuddy/
├── Pages/
│   ├── MainPage.xaml              # Home screen
│   ├── AddGoalPage.xaml           # Study timer
│   ├── GoalsListPage.xaml         # History
│   ├── TipsPage.xaml              # Study tips
│   └── AboutUsPage.xaml           # About
├── Models/
│   └── GoalRecord.cs              # Data model
├── Services/
│   └── FirebaseHelper.cs          # Firebase integration
└── App.xaml                       # App resources
```

---

## 🔥 Firebase Setup (Optional)

The app uses a demo Firebase database. To use your own:

1. Create Firebase project at [console.firebase.google.com](https://console.firebase.google.com)
2. Enable Realtime Database
3. Update URL in `FirebaseHelper.cs`:
```csharp
private readonly FirebaseClient firebase = 
    new FirebaseClient("YOUR_FIREBASE_URL");
```

4. Set database rules:
```json
{
  "rules": {
    "GoalRecords": {
      ".read": true,
      ".write": true
    }
  }
}
```

---

## 👨‍💻 Developer

<div align="center">

<img src="https://user-images.githubusercontent.com/74038190/212284087-bbe7e430-757e-4901-90bf-4cd2ce3e1852.gif" width="80">

**Abbas Mohammad Khaled Ali**

[![LinkedIn](https://img.shields.io/badge/LinkedIn-%230077B5.svg?style=for-the-badge&logo=linkedin&logoColor=white)](https://linkedin.com/in/mohmmad-abbas)
[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/ABBAS-PROJECT)
[![Email](https://img.shields.io/badge/Email-D14836?style=for-the-badge&logo=gmail&logoColor=white)](mailto:mkabbas2014@gmail.com)

🎓 **Universiti Tenaga Nasional** | 📍 **Riyadh, Saudi Arabia** | 🆔 **SW01081578**

</div>

---

## 📄 License

This project is developed for educational purposes as part of mobile application development coursework.

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!

Feel free to check [issues page](https://github.com/ABBAS-PROJECT/StudyBuddy/issues).

---

<div align="center">

<img src="https://user-images.githubusercontent.com/74038190/216122041-518ac897-8d92-4c6b-9b3f-ca01dcaf38ee.png" width="100" />

### ⭐ If this project helped you, give it a star!

**Made with ❤️ and .NET MAUI**

<img src="https://user-images.githubusercontent.com/74038190/212284158-e840e285-664b-44d7-b79b-e264b5e54825.gif" width="300">

</div>
