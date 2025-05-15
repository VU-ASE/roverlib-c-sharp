
# Dev-time image with SDK and formatter installed
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Install dotnet-format globally
RUN dotnet tool install -g dotnet-format

# Make sure dotnet tools are in the PATH
ENV PATH="${PATH}:/root/.dotnet/tools"

RUN apt-get update && \
    apt-get install -y \
    sudo \
    git \
    curl \
    gnupg \
    make \
    build-essential \
    pkg-config \
    libzmq3-dev \
    libssl-dev \
    zlib1g-dev \
    libncurses5-dev \
    libgdbm-dev \
    libnss3-dev \
    libsqlite3-dev \
    libreadline-dev \
    libffi-dev \
    libbz2-dev
