#!/bin/bash
echo 'Starting Build command'

cd "/media/yasha/storage/repositories/gamejam-2025/"

echo "Discarting local changes"
git reset --hard

echo "Downloading latest changes"
git pull

echo "Starting Unity Build"

/media/yasha/storage/UnityInstalls/6000.0.35f1/Editor/Unity -quit -batchmode -projectPath "/media/yasha/storage/repositories/gamejam-2025/" -username "ricardoandres2002@hotmail.com" -password "Yuramasa2177-" -activeBuildProfile "Assets/Settings/Build Profiles/New Web Profile.asset" -build "/home/yasha/HostedGames/GameJam2025/"
