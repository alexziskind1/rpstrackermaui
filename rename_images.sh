#!/bin/bash

# Specify the directory
dir="RPS.UI/Resources/Images/avatars/males"

# Change to the specified directory
cd "$dir"

# Iterate over each image file in the directory
for file in *; do
    # Check if the file name contains an underscore
    if [[ $file == *_* ]]; then
        # Replace the underscore with nothing
        newfile=$(echo $file | tr -d '_')

        # Rename the file
        mv "$file" "$newfile"
    fi
done