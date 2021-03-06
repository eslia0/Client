﻿
public class LoginPacket : IPacket<LoginData>
{
    LoginData m_data;

    public LoginPacket(LoginData data) // 데이터로 초기화(송신용)
    {
        m_data = data;
    }

    public LoginPacket(byte[] data) // 패킷을 데이터로 변환(수신용)
    {
        LoginSerializer serializer = new LoginSerializer();
        serializer.SetDeserializedData(data);
        m_data = new LoginData();
        serializer.Deserialize(ref m_data);
    }

    public byte[] GetPacketData() // 바이트형 패킷(송신용)
    {
        LoginSerializer serializer = new LoginSerializer();
        serializer.Serialize(m_data);
        return serializer.GetSerializedData();
    }

    public LoginData GetData() // 데이터 얻기(수신용)
    {
        return m_data;
    }

    public int GetPacketId()
    {
        return (int)ClientPacketId.Login;
    }
}