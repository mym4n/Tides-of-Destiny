using System;
using System.Net;
using System.Net.Sockets;

namespace SeaWeed {
    public struct float2 { 
        public float x;
        public float y;
    }
    public struct int2 {
        public int x;
        public int y;
    }
    public class node {
        public float2 pos;
        public bool isPhysical;
    }
    public class Area { // make them async :3
        public int id;
        public node[] Nodes;
    }
    public class ServerInstance { // call update logic on the Areas asyncly
        public Area[] areas;
        public TcpClient tcpClient;
        public TcpListener tcpListener;
        public int port;
    }
}