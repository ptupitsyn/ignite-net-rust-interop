#!/bin/bash

mkdir bin

cd dotnet/libignite
dotnet publish --configuration Release --runtime linux-x64 --output publish
cp publish/libignite.so ../../bin

cd ../../rust/ignite-client-test
cargo build
cp target/debug/ignite-client-test ../../bin

cd ../../bin
export LD_LIBRARY_PATH=$(pwd)
./ignite-client-test