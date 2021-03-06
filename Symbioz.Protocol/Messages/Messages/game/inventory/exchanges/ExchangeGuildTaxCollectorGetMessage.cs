


















// Generated on 06/04/2015 18:44:52
using System;
using System.Collections.Generic;
using System.Linq;
using Symbioz.DofusProtocol.Types;
using Symbioz.Utils;

namespace Symbioz.DofusProtocol.Messages
{

public class ExchangeGuildTaxCollectorGetMessage : Message
{

public const ushort Id = 5762;
public override ushort MessageId
{
    get { return Id; }
}

public string collectorName;
        public short worldX;
        public short worldY;
        public int mapId;
        public ushort subAreaId;
        public string userName;
        public double experience;
        public IEnumerable<Types.ObjectItemGenericQuantity> objectsInfos;
        

public ExchangeGuildTaxCollectorGetMessage()
{
}

public ExchangeGuildTaxCollectorGetMessage(string collectorName, short worldX, short worldY, int mapId, ushort subAreaId, string userName, double experience, IEnumerable<Types.ObjectItemGenericQuantity> objectsInfos)
        {
            this.collectorName = collectorName;
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.subAreaId = subAreaId;
            this.userName = userName;
            this.experience = experience;
            this.objectsInfos = objectsInfos;
        }
        

public override void Serialize(ICustomDataOutput writer)
{

writer.WriteUTF(collectorName);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteInt(mapId);
            writer.WriteVarUhShort(subAreaId);
            writer.WriteUTF(userName);
            writer.WriteDouble(experience);
            writer.WriteUShort((ushort)objectsInfos.Count());
            foreach (var entry in objectsInfos)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(ICustomDataInput reader)
{

collectorName = reader.ReadUTF();
            worldX = reader.ReadShort();
            if ((worldX < -255) || (worldX > 255))
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : (worldX < -255) || (worldX > 255)");
            worldY = reader.ReadShort();
            if ((worldY < -255) || (worldY > 255))
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : (worldY < -255) || (worldY > 255)");
            mapId = reader.ReadInt();
            subAreaId = reader.ReadVarUhShort();
            if (subAreaId < 0)
                throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            userName = reader.ReadUTF();
            experience = reader.ReadDouble();
            if ((experience < -9.007199254740992E15) || (experience > 9.007199254740992E15))
                throw new Exception("Forbidden value on experience = " + experience + ", it doesn't respect the following condition : (experience < -9.007199254740992E15) || (experience > 9.007199254740992E15)");
            var limit = reader.ReadUShort();
            objectsInfos = new Types.ObjectItemGenericQuantity[limit];
            for (int i = 0; i < limit; i++)
            {
                 (objectsInfos as Types.ObjectItemGenericQuantity[])[i] = new Types.ObjectItemGenericQuantity();
                 (objectsInfos as Types.ObjectItemGenericQuantity[])[i].Deserialize(reader);
            }
            

}


}


}