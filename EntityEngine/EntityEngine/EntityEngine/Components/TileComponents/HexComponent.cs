﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityEngine.Components.Component_Parents;
using Microsoft.Xna.Framework;
using EntityEngine.Components.TileComponents;
using EntityEngine.Components.Sprites;


namespace EntityEngine.Components.TileComponents
{
    public class HexComponent : UpdateableComponent
    {
        Vector2 coordPosition;
        public Vector2 getCoordPosition()
        {
            return coordPosition;
        }
        public Boolean checkCoords(Vector2 myVector)
        {
            if (myVector == coordPosition)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public HexComponent n, ne, se, s, sw, nw;
        public HexComponent getAdjacent(Orient myOar)
        {
            switch (myOar)
            {
                case Orient.n:
                    return n;
                case Orient.ne:
                    return ne;
                case Orient.se:
                    return se;
                case Orient.s:
                    return s;
                case Orient.sw:
                    return sw;
                case Orient.nw:
                    return nw;

                default:
                    return this;

            }
        }

        //As there can only be one unit per tile, there is but one unit var
        UnitComponent unit;
        public UnitComponent GetUnit()
        {
            return unit;
        }
        public void SetUnit(UnitComponent myUnit)
        {
            unit = myUnit;   
        }
        public bool HasUnit()
        {
            return (unit!=null);
        }

        Visibility visibility;
        public Visibility GetVisibility()
        {
            return visibility;
        }
        public void SetVisibility(Visibility myVis)
        {
            visibility = myVis;
        }

        //List of counters on top of the hex.
        List<TerrainComponent> terrainList = new List<TerrainComponent>();
        public void AddTerrain(TerrainComponent myTerrain)
        {
            terrainList.Add(myTerrain);
        }
        public void RemoveTerrain(TerrainComponent myTerrain)
        {
            terrainList.Remove(myTerrain);
        }
        public List<TerrainComponent> GetTerrain()
        {
            return terrainList;
        }

        public HexComponent(Entity myParent, Vector2 myCoordPosition) : base(myParent)
        {
            this.name = "HexComponent";
            coordPosition = myCoordPosition;
        }

        public void setAdjacent(HexComponent N, HexComponent NE, HexComponent SE, HexComponent S, HexComponent SW, HexComponent NW)
        {
            n = N; ne = NE; se = SE; s = S; sw = SW; nw = NW;
        }

        public void SetFog(Visibility myVis)
        {
            visibility = myVis;
            HexComponent hexComp = this;
            Entity hexEntity = hexComp._parent;
            SpriteComponent sprite = hexEntity.getDrawable("SpriteComponent") as SpriteComponent;

            if (myVis == Visibility.Visible)
            {
                sprite.setColor(Color.White);
                sprite._visible = true;                
            }

            if (myVis == Visibility.Explored)
            {
                sprite.setColor(Color.SlateGray);
                sprite._visible = true;
            }

            if (myVis == Visibility.Unexplored)
            {
                sprite.setColor(Color.White);
                sprite._visible = false;
            }
        }
    }
}
