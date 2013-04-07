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
        public Boolean HasUnit()
        {
            return (unit!=null);
        }

        //List of counters on top of the hex.
        List<TerrainComponent> terrainList = new List<TerrainComponent>();
        public void AddTerrain(TerrainComponent myPlaceable)
        {
            terrainList.Add(myPlaceable);
        }
        public void RemoveTerrain(TerrainComponent myPlaceable)
        {
            terrainList.Remove(myPlaceable);
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
            if (myVis == Visibility.Visible)
            {
                HexComponent hexComp = this;
                Entity hexEntity = hexComp._parent;
                SpriteComponent sprite = hexEntity.getDrawable("SpriteComponent") as SpriteComponent;

                sprite.setColor(Color.White);
                sprite._visible = true;
            }

            if (myVis == Visibility.Explored)
            {
                HexComponent hexComp = this;
                Entity hexEntity = hexComp._parent;
                SpriteComponent sprite = hexEntity.getDrawable("SpriteComponent") as SpriteComponent;

                sprite.setColor(Color.Gray);
                sprite._visible = true;
            }

            if (myVis == Visibility.Unexplored)
            {
                HexComponent hexComp = this;
                Entity hexEntity = hexComp._parent;
                SpriteComponent sprite = hexEntity.getDrawable("SpriteComponent") as SpriteComponent;

                sprite.setColor(Color.White);
                sprite._visible = false;
            }
        }
    }
}
