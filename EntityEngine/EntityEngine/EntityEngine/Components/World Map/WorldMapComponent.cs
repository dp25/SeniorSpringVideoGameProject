﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityEngine.Components.Component_Parents;
using Microsoft.Xna.Framework;
using EntityEngine.Components.TileComponents;
using EntityEngine.Components.Sprites;
using Microsoft.Xna.Framework.Graphics;

namespace EntityEngine.Components.World_Map
{
    public class WorldMapComponent : Component
    {
        List<Entity> nodeEntityList = new List<Entity>();
        List<NodeComponent> nodeList = new List<NodeComponent>();
        public void AddNode(NodeComponent myNode)
        {
            nodeList.Add(myNode);
            nodeEntityList.Add(myNode._parent);
        }
        public void AddNode(Entity myEnt)
        {
            nodeList.Add(myEnt.GetComponent("NodeComponent") as NodeComponent);
            nodeEntityList.Add(myEnt);
        }
        public List<Entity> GetNodeEntityList()
        {
            return nodeEntityList;
        }

        Entity pointerEntity;

        NodeComponent selectedNode;
        public void SetSelectedNode(NodeComponent myNode)
        {
            selectedNode = myNode;
        }

        public WorldMapComponent()
        {
            this.name = "WorldMapComponent";
        }

        public void CreateNode(string myLevelName, NodeState myNodeState, Vector2 myPosition,Texture2D myTexture)
        {
            Entity nodeEntity = new Entity(1, State.ScreenState.WORLD_MAP);
            nodeEntity.AddComponent(new SpriteComponent(true, myPosition, myTexture));
            nodeEntity.AddComponent(new CameraComponent(myPosition));
            nodeEntity.AddComponent(new ClickableComponent(myPosition,myTexture.Width,myTexture.Height));
            nodeEntity.AddComponent(new NodeComponent(myNodeState,myLevelName));

            AddNode(nodeEntity);
            EntityManager.AddEntity(nodeEntity);
        }
        public Entity CreateAndReturnNode(string myLevelName, NodeState myNodeState, Vector2 myPosition, Texture2D myTexture)
        {
            Entity nodeEntity = new Entity(1, State.ScreenState.WORLD_MAP);
            nodeEntity.AddComponent(new SpriteComponent(true, myPosition, myTexture));
            nodeEntity.AddComponent(new CameraComponent(myPosition));
            nodeEntity.AddComponent(new ClickableComponent(myPosition, myTexture.Width, myTexture.Height));
            nodeEntity.AddComponent(new NodeComponent(myNodeState, myLevelName));

            AddNode(nodeEntity);
            EntityManager.AddEntity(nodeEntity);

            return nodeEntity;
        }

        public void CreatePointer(Entity myStartingNode, Vector2 myOffset,Texture2D myTexture)
        {
            SpriteComponent sprite = myStartingNode.GetDrawable("SpriteComponent") as SpriteComponent;

            pointerEntity = new Entity(1, State.ScreenState.WORLD_MAP);
            pointerEntity.AddComponent(new SpriteComponent(true, sprite.position + myOffset, myTexture));
            pointerEntity.AddComponent(new CameraComponent(sprite.position + myOffset));
            pointerEntity.AddComponent(new PointerComponent(sprite.position + myOffset));

            EntityManager.AddEntity(pointerEntity);
        }

        //Uses the specificed node
        public void SelectNode(NodeComponent myNode)
        {
        }

        //Uses the currently selected node
        public void SelectNode()
        {

        }
    }
}