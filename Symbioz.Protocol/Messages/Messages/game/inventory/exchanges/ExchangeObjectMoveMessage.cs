


















// Generated on 06/04/2015 18:44:54
using System;
using System.Collections.Generic;
using System.Linq;
using Symbioz.DofusProtocol.Types;
using Symbioz.Utils;

namespace Symbioz.DofusProtocol.Messages
{

public class ExchangeObjectMoveMessage : Message
{

public const ushort Id = 5518;
public override ushort MessageId
{
    get { return Id; }
}

public uint objectUID;
        public int quantity;
        

public ExchangeObjectMoveMessage()
{
}

public ExchangeObjectMoveMessage(uint objectUID, int quantity)
        {
            this.objectUID = objectUID;
            this.quantity = quantity;
        }
        

public override void Serialize(ICustomDataOutput writer)
{

writer.WriteVarUhInt(objectUID);
            writer.WriteVarInt(quantity);
            

}

public override void Deserialize(ICustomDataInput reader)
{

objectUID = reader.ReadVarUhInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
            quantity = reader.ReadVarInt();
            

}


}


}