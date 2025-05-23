# Default target: build
.PHONY: all lint clean test build
all: build

build:
	@echo "Building solution..."
	cd src && dotnet build --configuration Release && dotnet publish
	mkdir -p roverlib-c-sharp
	cp src/roverlib/bin/Release/netstandard2.1/publish/*.dll roverlib-c-sharp/


test:
	@echo "Running tests..."
	cd src && ASE_SERVICE=`cat ./roverlib.tests/bootspectest.json` dotnet test --configuration Release

lint:
	@echo "Checking code format..."
	cd src && dotnet format --verify-no-changes

clean:
	@echo "Cleaning..."
	cd src && dotnet clean

# Extra testing to run the sample file
sample: build
	@echo "Running Sample..."
	cd sample-service && ASE_SERVICE=`cat ../src/roverlib.tests/bootspectest.json` dotnet run
