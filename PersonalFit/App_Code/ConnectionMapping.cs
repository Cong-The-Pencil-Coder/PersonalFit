﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConnectionMapping
/// </summary>
public class ConnectionMapping<T>
{
    public ConnectionMapping()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private readonly Dictionary<T, HashSet<string>> _connections = new Dictionary<T, HashSet<string>>();

    public int Count
    {
        get
        {
            return _connections.Count;
        }
    }

    public void Add(T key, string connectionId)
    {
        lock (_connections)
        {
            HashSet<string> connections;
            if(!_connections.TryGetValue(key, out connections))
            {
                connections = new HashSet<string>();
                _connections.Add(key, connections);
            }

            lock(connections)
            {
                connections.Add(connectionId);
            }
        }
    }

    public IEnumerable<string> GetConnections(T key)
    {
        HashSet<string> connections;
        if(_connections.TryGetValue(key, out connections))
        {
            return connections;
        }
        return Enumerable.Empty<string>();
    }

    public void Remove(T key, string connectionId)
    {
        lock(_connections)
        {
            HashSet<String> connections;
            if(!_connections.TryGetValue(key, out connections))
            {
                return;
            }

            lock(connections)
            {
                connections.Remove(connectionId);

                if(connections.Count == 0)
                {
                    _connections.Remove(key);
                }
            }
        }
    }
}