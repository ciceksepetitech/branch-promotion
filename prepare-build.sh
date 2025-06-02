#!/bin/bash
set -e

# get project name.
TOKENS=( "PROJECT_NAME:BranchPromotion"
         "PROJECT_NAME_LOWER:branch-promotion"
         "EXECUTABLE_NAME:BranchPromotion.Api" )

# get build files if they are not exist.
if [ ! -d ./.build/src ]; then
    echo "Build files not found. Downloading from remote repository..."
    # add git credentials if CI enabled.
    if [ "$CI" = true ]; then
        git clone https://${GIT_APP_USERNAME}:${GIT_APP_PASSWORD}@github.com/ciceksepetitech/build.git .build
        (cd .build && git checkout dotnet-8-0)
    else
        git clone https://github.com/ciceksepetitech/build.git .build
        (cd .build && git checkout dotnet-8-0)
    fi
fi

# replace projectname variables to given project name.
echo "Build files are getting ready..."
for path in ./.build/src/*; do
    for token in "${TOKENS[@]}" ; do
        KEY="${token%%:*}"
        VALUE="${token##*:}"
        if [[ $(uname) == 'Darwin' ]]; then
            sed -i '' -e "s/%$KEY%/$VALUE/g" $path
        else
            sed -i "s/%$KEY%/$VALUE/g" $path
        fi 
    done
    echo "${path} ok."
done
echo "${name} project is ready to build."
