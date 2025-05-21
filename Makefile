# Default target: build
.PHONY: all lint clean test build
all: build

build:
	@echo "Building solution..."
	cd src && dotnet build --configuration Release


test:
	@echo "Running tests..."
	cd src && dotnet test --configuration Release

lint:
	@echo "Checking code format..."
	cd src && dotnet format --verify-no-changes

clean:
	@echo "Cleaning..."
	cd src && dotnet clean

# dotnet publish /workspace/roverlib-c-sharp/src/roverlib/roverlib.csproj -c Release -f netstandard2.1 -o ./publish
publish: build
	cp README ./src
	cd src && dotnet pack -c Release
	@echo "Package saved at ./src/roverlib/bin/Release/roverlib.1.0.0.nupkg"

# Extra testing to run the sample file
sample: build
	@echo "Running Sample..."
	touch /workspace/roverlib-c-sharp/sample.csx
	cd src && dotnet script /workspace/roverlib-c-sharp/sample.csx --no-cache --no-restore --debug --output /workspace/roverlib-c-sharp/logs.txt