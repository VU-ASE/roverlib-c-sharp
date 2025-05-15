# Makefile for C# project in src/

SOLUTION = $(wildcard src/*.sln)
PROJECTS = $(wildcard src/**/*.csproj)

# Default target: build
.PHONY: all
all: build

.PHONY: build
build:
	@echo "Building solution..."
	cd src && dotnet build --configuration Release

.PHONY: test
test:
	@echo "Running tests..."
	cd src && dotnet test --configuration Release

.PHONY: lint
lint:
	@echo "Checking code format..."
	cd src && dotnet format --verify-no-changes

.PHONY: clean
clean:
	@echo "Cleaning..."
	cd src && dotnet clean

tests:
	@echo "Running Sample..."
	cd src && dotnet script /workspace/roverlib-c-sharp/sample.csx
