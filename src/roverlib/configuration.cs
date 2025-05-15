namespace roverlib;

using System.Runtime.Intrinsics.X86;
using QuickType;


public class ServiceConfiguration{
    private readonly Dictionary<string, float> floatOptions = [];
    private readonly Dictionary<string, string> stringOptions = [];
    private readonly Dictionary<string, bool> tunable = [];
    private ReaderWriterLockSlim rwlock = new();
    private long lastUpdate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public ServiceConfiguration(Service service){
        for(int i = 0; i < service.Configuration.Length; i++){
            var c = service.Configuration[i];
            
            // these nullability checks should never fail, but are mainly for warning suppression 
            if(c.Type == TypeEnum.Number && c.Value != null && c.Value.Value.Double != null){
                this.floatOptions[c.Name] = (float)c.Value.Value.Double;
            }
            else if(c.Type == TypeEnum.String && c.Value != null){
                this.stringOptions[c.Name] = c.Value.Value.String;
            }

            if(c.Tunable == true){
                this.tunable[c.Name] = (bool)c.Tunable;
            }
        }
    }

    //  Returns the float value of the configuration option with the given name, returns an error if the option does not exist or does not exist for this type
    //  Reading is NOT thread-safe, but we accept the risks because we assume that the user program will read the configuration values repeatedly
    //  If you want to read the configuration values concurrently, you should use the GetFloatSafe method
    public float GetFloat(string name){
        if(!floatOptions.ContainsKey(name)){
            Roverlog.Fatal($"No float configuration option with the name {name}");
            throw new KeyNotFoundException($"No float configuration option with the name {name}");
        }

        return floatOptions[name];
    }

    public float GetFloatSafe(string name){
        rwlock.EnterReadLock();
        try{
            return GetFloat(name);
        }
        finally{
            rwlock.ExitReadLock();
        }
    }

    // Returns the string value of the configuration option with the given name, returns an error if the option does not exist or does not exist for this type
    // Reading is NOT thread-safe, but we accept the risks because we assume that the user program will read the configuration values repeatedly
    // If you want to read the configuration values concurrently, you should use the GetStringSafe method    
    public string GetString(string name){
        if(!stringOptions.ContainsKey(name)){
            Roverlog.Fatal($"No string configuration option with the name {name}");
            throw new KeyNotFoundException($"No string configuration option with the name {name}");
        }

        return stringOptions[name];
    }
    
    public string GetStringSafe(string name){
        rwlock.EnterReadLock();
        try{
            return GetString(name);
        }
        finally{
            rwlock.ExitReadLock();
        }
    }

    // Set the float value of the configuration option with the given name (thread-safe)    
    public void SetFloat(string name, float value){
        rwlock.EnterWriteLock();
        try{
            if(tunable.ContainsKey(name)){
                if(!floatOptions.ContainsKey(name)){
                    Roverlog.Error($"{name} : {value} Is not of type Float");
                    return;
                }
                floatOptions[name] = value;
                Roverlog.Info($"{name} : {value} Set float configuration option");
            }
            else{
                Roverlog.Error($"{name} : {value} Attempted to set non-tunable float configuration option");
            }
        }
        finally{
            rwlock.ExitWriteLock();
        }
    }

    // Set the string value of the configuration option with the given name (thread-safe)    
    public void SetString(string name, string value){
        rwlock.EnterWriteLock();
        try{
            if(tunable.ContainsKey(name)){
                if(!stringOptions.ContainsKey(name)){
                    Roverlog.Error($"{name} : {value} Is not of type String");
                    return;
                }
                stringOptions[name] = value;
                Roverlog.Info($"{name} : {value} Set string configuration option");
            }
            else{
                Roverlog.Error($"{name} : {value} Attempted to set non-tunable string configuration option");
            }
        }
        finally{
            rwlock.ExitWriteLock();
        }
    }
} 
