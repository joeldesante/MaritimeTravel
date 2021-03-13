using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MaritimeTravel.Source.Scene {
    class SceneManager {
        private Dictionary<string, Scene> registeredScenes;

        public void LoadScenesFromFile() {
            string sceneDirectory = "J:\\Development\\Games\\MaritimeTravel\\MaritimeTravel\\Scenes";
            string[] scenes = System.IO.Directory.GetFiles(sceneDirectory);

            List<XmlDocument> scenesXml = new List<XmlDocument>();
            foreach (string path in scenes) {
                XmlDocument xmlFile = new XmlDocument();
                xmlFile.Load(path);
                scenesXml.Add(xmlFile);
            }
        }

        public string printNodeStructure(XmlNode node, int depth) {

            if (node == null) { return "Fuck you"; }

            string spaces = "";
            for (int i = 0; i < depth; i++) {
                spaces += "\t";
            }
            string output = spaces + "- " + node.Name + "\n";

            XmlNodeList list = node.ChildNodes;
            foreach ( XmlNode innerNode in list) {
                output += this.printNodeStructure(innerNode, depth + 1);
            }

            return output;
        }
    }
}
