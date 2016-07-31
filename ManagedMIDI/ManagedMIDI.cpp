// This is the main DLL file.

#include "stdafx.h"

using namespace System;
using namespace System::Text;
using namespace System::Collections;
using namespace System::Threading;
using namespace System::IO;
using namespace System::Runtime::InteropServices;
using namespace System::Windows::Forms;

namespace Janus
{
	namespace ManagedMIDI
	{
		struct MidiInCaps
		{
			public:
			short ManufacturerID;
			short ProductID;
			int DriverVersion;
			char Label[32];
			int Support;
};

struct MidiOutCaps
{
	public:
	short ManufacturerID;
	short ProductID;
	int DriverVersion;
	char Label[32];
	short Technology;
	short Voices;
	short Notes;
	short ChannelMask;
	int Support;
};

struct MidiEvent
{
	public:
	int DeltaTime;
	int StreamID;
	int Event;
};

struct MidiHdr
{
	public:
	void* Data;
	int BufferLength;
	int BytesRecorded;
	IntPtr User;
	int Flags;
	IntPtr Next;
	IntPtr Reserved;
	int Offset;
	IntPtr Reserved1;
	IntPtr Reserved2;
	IntPtr Reserved3;
	IntPtr Reserved4;
	IntPtr Reserved5;
	IntPtr Reserved6;
	IntPtr Reserved7;
	IntPtr Reserved8;
};

struct MidiProp
{
	public:
	int Struct;
	int Value;
};

struct MMTime
{
	public:
	int Type;
	int Ticks;
};

public delegate void Callback(IntPtr MidiInHandle, int Message, int Instance, int dw1, int dw2);

// MIDI functions from winmm.dll

[DllImport("winmm.dll")] extern int midiInGetNumDevs();
[DllImport("winmm.dll")] extern int midiInGetDevCaps(int uDeviceID,MidiInCaps* lpCaps, int uSize);
[DllImport("winmm.dll")] extern int midiOutGetNumDevs();
[DllImport("winmm.dll")] extern int midiOutGetDevCaps(int uDeviceID,MidiOutCaps* lpCaps, int uSize);

[DllImport("winmm.dll")] extern int midiInOpen(interior_ptr<IntPtr> lphMidiIn, int uDeviceID, Callback^ dwCallback, int dwInstance, int dwFlags);
[DllImport("winmm.dll")] extern int midiInOpen(interior_ptr<IntPtr> lphMidiIn, int uDeviceID, int dwCallback, int dwInstance, int dwFlags);
[DllImport("winmm.dll")] extern int midiInClose(IntPtr hMidiIn);
[DllImport("winmm.dll")] extern int midiInStart(IntPtr hMidiIn);
[DllImport("winmm.dll")] extern int midiInStop(IntPtr hMidiIn);
[DllImport("winmm.dll")] extern int midiInReset(IntPtr hMidiIn);

[DllImport("winmm.dll")] extern int midiOutOpen(interior_ptr<IntPtr> lphMidiOut, int uDeviceID, int dwCallback, int dwInstance, int dwFlags);
[DllImport("winmm.dll")] extern int midiOutClose(IntPtr hMidiOut);
[DllImport("winmm.dll")] extern int midiOutReset(IntPtr hMidiOut);
[DllImport("winmm.dll")] extern int midiOutShortMsg(IntPtr hMidiOut, int dwMsg);
[DllImport("winmm.dll")] extern int midiOutLongMsg(IntPtr hMidiOut, MidiHdr* h, int size);
[DllImport("winmm.dll")] extern int midiOutPrepareHeader(IntPtr hMidiOut,MidiHdr* h,int size);
[DllImport("winmm.dll")] extern int midiOutUnprepareHeader(IntPtr hMidiOut,MidiHdr* h,int size);
[DllImport("winmm.dll")] extern int midiOutGetVolume(IntPtr hMidiOut,unsigned int* volume);
[DllImport("winmm.dll")] extern int midiOutSetVolume(IntPtr hMidiOut,unsigned int volume);

[DllImport("winmm.dll")] extern int midiStreamOpen(interior_ptr<IntPtr> hMidiOut, int* DeviceID, int cMidi, int dwCallback, int dwInstance, int fdwOpen);
[DllImport("winmm.dll")] extern int midiStreamClose(IntPtr hMidiOut);
[DllImport("winmm.dll")] extern int midiStreamOut(IntPtr hMidiOut,MidiHdr* hdr,int Size);
[DllImport("winmm.dll")] extern int midiStreamRestart(IntPtr hMidiOut);
[DllImport("winmm.dll")] extern int midiStreamPause(IntPtr hMidiOut);
[DllImport("winmm.dll")] extern int midiStreamStop(IntPtr hMidiOut);
[DllImport("winmm.dll")] extern int midiStreamProperty(IntPtr hMidiOut,MidiProp* lpPropData,unsigned int Property);
[DllImport("winmm.dll")] extern int midiStreamPosition(IntPtr hMidiOut,MMTime* mmt,int Size);

[DllImport("kernel32.dll")] extern int CreateEvent(int attr,int bManualReset,int bInitialState,String^ lpName);
[DllImport("kernel32.dll")] extern int ResetEvent(int evt);
[DllImport("kernel32.dll")] extern int WaitForSingleObject(int evt,int ms);
[DllImport("kernel32.dll")] extern int CloseHandle(int evt);

// constants

public ref class MM_MIM sealed
{
	private:
	MM_MIM(){}
public:
static MM_MIM(){}
static const int OPEN = 961;
static const int CLOSE = 962;
static const int DATA = 963;
static const int LONGDATA = 964;
static const int ERROR = 965;
static const int LONGERROR = 966;
};

private ref class CALLBACK sealed
{
	private:
	CALLBACK(){}
public:
static CALLBACK(){}
static const int NULL = 0;
static const int WINDOW = 0x10000;
static const int THREAD = 0x20000;
static const int FUNCTION = 0x30000;
static const int EVENT = 0x50000;
static const int TYPEMASK = 0x70000;
};

private ref class MIDIPROP sealed
{
	private:
	MIDIPROP(){}
public:
static MIDIPROP(){}
static const unsigned int SET = 0x80000000;
static const unsigned int GET = 0x40000000;
static const unsigned int TIMEDIV = 0x00000001;
static const unsigned int TEMPO = 0x00000002;
};

private ref class MHDR sealed
{
	private:
	MHDR(){}
public:
static MHDR(){}
static const int DONE = 1;
static const int PREPARED = 2;
static const int INQUEUE = 4;
static const int ISSTRM = 8;
};

private ref class TIME sealed
{
	private:
	TIME(){}
public:
static TIME(){}
static const int MS = 0x01;
static const int SAMPLES = 0x02;
static const int BYTES = 0x04;
static const int SMPTE = 0x08;
static const int MIDI = 0x10;
static const int TICKS = 0x20;
};

private ref class WAIT sealed
{
	private:
	WAIT(){}
public:
static WAIT(){}
static const int OBJECT_0 = 0x0;
static const int TIMEOUT = 0x102;
};

//const int INFINITE = -1;
//const int MEVT_F_CALLBACK = 0x40000000;

// error handling

private ref class MMSYSERR sealed
{
	private:
	MMSYSERR(){}
public:
static MMSYSERR(){}

static const int BASE = 0;
static const int NOERROR = 0;
static const int ERROR = 1;
static const int BADDEVICEID = 2;
static const int NOTENABLED = 3;
static const int ALLOCATED = 4;
static const int INVALHANDLE = 5;
static const int NODRIVER = 6;
static const int NOMEM = 7;
static const int NOTSUPPORTED = 8;
static const int BADERRNUM = 9;
static const int INVALFLAG = 10;
static const int INVALPARAM = 11;
static const int HANDLEBUSY = 12;
static const int INVALIDALIAS = 13;
static const int LASTERROR = 13;

static String^ ToString(int err)
{
	String ^s = String::Concat("error #",err.ToString(),": ");
	switch (err)
	{
		case ERROR: s = String::Concat(s,"error"); break;
		case BADDEVICEID: s = String::Concat(s,"bad device id"); break;
		case NOTENABLED: s = String::Concat(s,"not enabled"); break;
		case ALLOCATED: s = String::Concat(s,"allocated"); break;
		case INVALHANDLE: s = String::Concat(s,"invalid handle"); break;
		case NODRIVER: s = String::Concat(s,"no driver"); break;
		case NOMEM: s = String::Concat(s,"no memory"); break;
		case NOTSUPPORTED: s = String::Concat(s,"not supported"); break;
		case BADERRNUM: s = String::Concat(s,"bad error number"); break;
		case INVALFLAG: s = String::Concat(s,"invalid flag"); break;
		case INVALPARAM: s = String::Concat(s,"invalid parameter"); break;
		case HANDLEBUSY: s = String::Concat(s,"handle busy"); break;
		case INVALIDALIAS: s = String::Concat(s,"invalid alias"); break;
		default: s = String::Concat(s,"unknown");
}
return s;
}
};

private ref class MIDIERR sealed
{
	private:
	MIDIERR(){}
public:
static MIDIERR(){}

static const int BASE = 64;
static const int UNPREPARED = 64;
static const int STILLPLAYING = 65;
static const int NOMAP = 66;
static const int NOTREADY = 67;
static const int NODEVICE = 68;
static const int INVALIDSETUP = 69;
static const int LASTERROR = 69;

static String^ ToString(int err)
{
	String ^s = String::Concat("error #",err.ToString(),": ");
	switch (err)
	{
		case UNPREPARED: s = String::Concat(s,"unprepared"); break;
		case STILLPLAYING: s = String::Concat(s,"still playing"); break;
		case NOMAP: s = String::Concat(s,"no map"); break;
		case NOTREADY: s = String::Concat(s,"not ready"); break;
		case NODEVICE: s = String::Concat(s,"no device"); break;
		case INVALIDSETUP: s = String::Concat(s,"invalid setup"); break;
		default: s = String::Concat(s,"unknown");
}
return s;
}
};

private ref class Error sealed
{
	private:
	Error(){}
public:
static Error(){}
static String^ ToString(int err)
{
	if (err >= MIDIERR::BASE)
	return MIDIERR::ToString(err);
	else return MMSYSERR::ToString(err);
}
};

/// <summary>
/// a wrapper class for the winapi midiIn device functions
/// showing the number of midi input devices on the system
/// and their capabilities
/// </summary>
public ref class MidiInDevs
{
	public:
	int NumDevs;
	MidiInDevs()
	{
		NumDevs = midiInGetNumDevs();
		DevCaps = new MidiInCaps[NumDevs];
		int err;
		for (int i = 0;i <= NumDevs-1;i++)
		{
			err = midiInGetDevCaps(i,&DevCaps[i],sizeof(MidiInCaps));
			if (err != 0) MessageBox::Show(String::Concat("error in midiingetnumdevs: ",err.ToString()));
}
}
String^ Label(int i)
{
	return gcnew String(DevCaps[i].Label);
}
private:
MidiInCaps* DevCaps;
};

/// <summary>
/// a wrapper class for the winapi midiOut functions
/// showing the number of midi output devices on the system
/// and their capabilities
/// </summary>
public ref class MidiOutDevs
{
	public:
	int NumDevs;
	MidiOutDevs()
	{
		NumDevs = midiOutGetNumDevs();
		DevCaps = new MidiOutCaps[NumDevs];
		int err;
		for (int i = 0;i <= NumDevs-1;i++)
		{
			err = midiOutGetDevCaps(i,&DevCaps[i],sizeof(MidiOutCaps));
			if (err != 0) MessageBox::Show(String::Concat("error in midioutgetnumdevs: ",err.ToString()));
}
}
String^ Label(int i)
{
	return gcnew String(DevCaps[i].Label);
}
private:
MidiOutCaps* DevCaps;
};

/// <summary>
/// a class representing a standard (3 byte) midi message
/// </summary>
public ref class MidiMsg
{
	public:
	int Data;
	MidiMsg()
	{
		Data = 0;
}
MidiMsg(MidiMsg^ m)
{
	Data = m->Data;
}
MidiMsg(int d)
{
	Data = d;
}
MidiMsg(int b1,int b2,int b3)
{
	SetBytes(b1,b2,b3);
}

property Byte Byte1
{
	Byte get(){ return (Byte)(Data&0xFF); }
void set(Byte value){ SetBytes(value,Byte2,Byte3); }
}

property Byte Byte2
{
	Byte get(){ return (Byte)((Data/0x100)&0xFF); }
void set(Byte value){ SetBytes(Byte1,value,Byte3); }
}

property Byte Byte3
{
	Byte get(){ return (Byte)((Data/0x10000)&0xFF); }
void set(Byte value){ SetBytes(Byte1,Byte2,value); }
}

property Byte Opcode{ Byte get(){ return (Byte)(Byte1/0x10); } }

property Byte Channel
{
	Byte get(){ return (Byte)(Byte1%0x10); }
void set(Byte value){ Byte1 = (Byte)(Byte1&0xF0+value); }
}

void SetBytes(int b1,int b2,int b3)
{
	Data = b1+b2*0x100+b3*0x10000;
}

virtual String^ ToString() override
{
	return String::Concat(Byte1.ToString("X2"),".",Byte2.ToString("X2"),".",Byte3.ToString("X2"));
}

property bool IsNote{ bool get(){ return (Opcode == 8 || Opcode == 9); } }
property bool IsNoteOn{ bool get(){ return (Opcode == 9 && Byte3>0); } }
property bool IsNoteOff{ bool get(){ return (Opcode == 8 || (Opcode == 9 && Byte3 == 0)); } }
property bool IsProgramChange{ bool get(){ return (Opcode == 0xC); } }
};

/// <summary>
/// shortcut for special midi message: note on
/// </summary>
public ref class NoteOnMsg : public MidiMsg
{
	public:
	NoteOnMsg(int note)
	{
		SetBytes(0x90,note,0x7F);
}
NoteOnMsg(int ch,int note)
{
	SetBytes(0x90+ch,note,0x7F);
}
};

/// <summary>
/// shortcut for special midi message: note off
/// </summary>
public ref class NoteOffMsg : public MidiMsg
{
	public:
	NoteOffMsg(int note)
	{
		SetBytes(0x80,note,0);
}
NoteOffMsg(int ch,int note)
{
	SetBytes(0x80+ch,note,0);
}
};

/// <summary>
/// shortcut for special midi message: program change
/// </summary>
public ref class ProgramChangeMsg : public MidiMsg
{
	public:
	ProgramChangeMsg(int program)
	{
		SetBytes(0xC0,program,0);
}
ProgramChangeMsg(int ch,int program)
{
	SetBytes(0xC0+ch,program,0);
}
};

/// <summary>
/// shortcut for special midi message: pitch wheel
/// </summary>
public ref class PitchWheelMsg : public MidiMsg
{
	public:
	PitchWheelMsg(int channel,int Pitch) // in tenths of a cent
	{
		int center = 0x2000;
		int units = (center+0x1000*Pitch/1000);
		if (units<0) units = 0;
		if (units>0x3FFF) units = 0x3FFF;
		int Lo = units&0x7F;
		int Hi = (units/0x80)&0x7F;
		SetBytes(0xE0+channel,Lo,Hi);
}
};

/// <summary>
/// a class representing a buffer which can hold several midi events plus a header
/// </summary>
class MidiBuffer
{
	public:
	MidiBuffer()
	{
}
MidiBuffer(int sz)
{
	Init(sz);
}
~MidiBuffer()
{
	delete Header;
	delete Events;
}
void Init(int sz)
{
	size = sz;
	filled = sz;
	Events = new MidiEvent[size];
	Header = new MidiHdr();
	Header->Data = &Events[0];
	Header->BufferLength = sizeof(MidiEvent)*sz;
}
int size,filled;
MidiHdr* Header;
MidiEvent* Events;
};

/// <summary>
/// a class representing a system exclusive message
/// </summary>
/*__gc public class SysExMsg
{
public:
	MidiHdr __nogc* Header;
	SysExMsg(int size)
	{
		Data = __nogc new char[size];
		Data[0] = 0xF0;
		Data[1] = 0x7F;
		Data[size-1] = 0xF7;
		Header = new MidiHdr();
		Header->Data = (void*)&Data[0];
		Header->BufferLength = size;
		Header->BytesRecorded = size;
	}
	~SysExMsg()
	{
		delete Data;
		delete Header;
	}
protected:
	char __nogc* Data;
	int size;
};*/

/// <summary>
/// a wrapper class for the winapi midiIn functions
/// representing a midi input port
/// </summary>
public ref class MidiInPort
{
	public:
	static MidiInPort^ Open(int DeviceID,Callback^ dwCallback)
	{
		MidiInPort^ p = gcnew MidiInPort();
		p->err = midiInOpen(&p->Handle,DeviceID,dwCallback,0,CALLBACK::FUNCTION);
		if (p->err != 0)
		{
			MessageBox::Show(String::Concat("device #",DeviceID.ToString(),"\n",Error::ToString(p->err)),"midiInOpen");
			return nullptr;
}
else return p;
}
static MidiInPort^ Open(int DeviceID,IntPtr WndHandle)
{
	MidiInPort^ p = gcnew MidiInPort();
	p->err = midiInOpen(&p->Handle,DeviceID,(int)WndHandle,0,CALLBACK::WINDOW);
	if (p->err != 0)
	{
		MessageBox::Show(String::Concat("device #",DeviceID.ToString(),"\n",Error::ToString(p->err)),"midiInOpen");
		return nullptr;
}
else return p;
}
void Close()
{
	err = midiInClose(Handle);
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiInClose");
}
void Start()
{
	err = midiInStart(Handle);
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiInStart");
}
void Stop()
{
	err = midiInStop(Handle);
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiInStop");
}
void Reset()
{
	err = midiInReset(Handle);
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiInReset");
}
private:
IntPtr Handle;
int err;
};

/// <summary>
/// a wrapper class for the winapi midiOut functions
/// representing a midi output port
/// </summary>
public ref class MidiOutPort
{
	public:
	static MidiOutPort^ Open(int dev)
	{
		MidiOutPort^ p = gcnew MidiOutPort();
		p->err = midiOutOpen(&p->Handle,dev,0,0,0);
		p->DeviceID = dev;
		if (p->err != 0)
		{
			MessageBox::Show(String::Concat("device #",dev.ToString(),"\n",Error::ToString(p->err)),"midiOutOpen");
			return nullptr;
}
else return p;
}
void Close()
{
	err = midiOutClose(Handle);
	if (err != 0) MessageBox::Show(String::Concat("device #",DeviceID.ToString(),"\n",Error::ToString(err)),"midiOutClose");
}
void Reset()
{
	err = midiOutReset(Handle);
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiOutReset");
}
void ShortMsg(MidiMsg^ m)
{
	err = midiOutShortMsg(Handle,m->Data);
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiOutShortMsg");
}
/*void SendSysEx(SysExMsg* m)
{
	Prepare(m->Header);
	err = midiOutLongMsg(Handle,m->Header,sizeof(MidiHdr));
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiOutLongMsg");
}*/
void Prepare(MidiHdr* h)
{
	err = midiOutPrepareHeader(Handle,h,sizeof(MidiHdr));
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiOutPrepareHeader");
}
void Unprepare(MidiHdr *h)
{
	err = midiOutUnprepareHeader(Handle,h,sizeof(MidiHdr));
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiOutUnprepareHeader");
}

property double Volume
{
	double get()
	{
		// 0 = silence, 1 = maximum
		unsigned int v = 0;
		err = midiOutGetVolume(Handle,&v);
		//if (err != 0) MessageBox::Show(Error::ToString(err),"midioutgetvolume");
		return ((double)(v&0xFFFF))/0xFFFF;
}
void set(double value)
{
	unsigned int v = (unsigned int)(value*0xFFFF);
	err = midiOutSetVolume(Handle,v*0x10001);
	//if (err != 0) MessageBox::Show(Error::ToString(err),"midioutsetvolume");
}
}
protected:
int DeviceID;
IntPtr Handle;
int err;
};

/// <summary>
/// a wrapper class for the winapi midiStream functions
/// represents a midi output stream, which can be used to play midi files
/// </summary>
public ref class MidiStream : public MidiOutPort
{
	public:
	static MidiStream^ Open(int dev,int Event)
	{
		MidiStream^ s = gcnew MidiStream();
		s->DeviceID = dev;
		s->err = midiStreamOpen(&s->Handle,&dev,1,Event,0,CALLBACK::EVENT);
		if (s->err != 0)
		{
			MessageBox::Show(String::Concat("device #",s->DeviceID.ToString(),"\n",Error::ToString(s->err)),"midiStreamOpen");
			return nullptr;
}
else return s;
}
void Start()
{
	err = midiStreamRestart(Handle);
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiStreamRestart");
	stopped = false;
}
void Out(MidiBuffer *b)
{
	b->Header->BytesRecorded = sizeof(MidiEvent)*b->filled;
	Prepare(b->Header);
	err = midiStreamOut(Handle,b->Header,sizeof(MidiHdr));
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiStreamOut");
}
void Pause()
{
	err = midiStreamPause(Handle);
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiStreamPause");
}
void Stop()
{
	err = midiStreamStop(Handle);
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiStreamStop");
	stopped = true;
}
void Close()
{
	err = midiStreamClose(Handle);
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiStreamClose");
	Handle = IntPtr(0);
}

property bool Stopped{ bool get(){ return stopped; } }

property int TimeDiv
{
	int get()
	{
		MidiProp* prop = new MidiProp();
		prop->Struct = sizeof(MidiProp);
		err = midiStreamProperty(Handle,prop,MIDIPROP::GET|MIDIPROP::TIMEDIV);
		if (err != 0) MessageBox::Show(Error::ToString(err),"midiStreamProperty: get timediv");
		return prop->Value;
}
void set(int value)
{
	MidiProp* prop = new MidiProp();
	prop->Struct = sizeof(MidiProp);
	prop->Value = value;
	err = midiStreamProperty(Handle,prop,MIDIPROP::SET|MIDIPROP::TIMEDIV);
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiStreamProperty: set timediv");
}
}

property double Tempo
{
	double get()
	{
		MidiProp* prop = new MidiProp();
		prop->Struct = sizeof(MidiProp);
		err = midiStreamProperty(Handle,prop,MIDIPROP::GET|MIDIPROP::TEMPO);
		if (err != 0) MessageBox::Show(Error::ToString(err),"midiStreamProperty: get tempo");
		return 60000000.0/prop->Value;
}
void set(double value)
{
	MidiProp* prop = new MidiProp();
	prop->Struct = sizeof(MidiProp);
	prop->Value = (int)(60000000.0/value);
	err = midiStreamProperty(Handle,prop,MIDIPROP::SET|MIDIPROP::TEMPO);
	if (err != 0) MessageBox::Show(Error::ToString(err),"midiStreamProperty: set tempo");
}
}

property int Position
{
	int get()
	{
		MMTime* mmt = new MMTime();
		mmt->Type = TIME::TICKS;
		err = midiStreamPosition(Handle,mmt,sizeof(MMTime));
		if (err != 0) throw gcnew Exception(Error::ToString(err));//MessageBox::Show(Error::ToString(err),"midiStreamPosition");
		return mmt->Ticks;
}
}
protected:
bool stopped;
};

public ref class TimedMsg abstract : public IComparable
{
	public:
	int Time;
	TimedMsg(int t)
	{
		Time = t;
}
property bool IsMidi{ virtual bool get() abstract; }
property bool IsMeta{ virtual bool get() abstract; }
virtual int CompareTo(Object^ obj)
{
	if(obj->GetType() == TimedMsg::typeid)
	{
		if (Time<dynamic_cast<TimedMsg^>(obj)->Time)
		return -1;
		else if (Time>dynamic_cast<TimedMsg^>(obj)->Time)
		return 1;
		else return 0;
}
throw gcnew ArgumentException("object is not a TimedMidiMsg");
}
};

/// <summary>
/// a class representing a midi message with time information
/// </summary>
public ref class TimedMidiMsg : public TimedMsg
{
	public:
	MidiMsg^ m;
	TimedMidiMsg(TimedMidiMsg^ _m) : TimedMsg(_m->Time)
	{
		m = gcnew MidiMsg(_m->m);
}
TimedMidiMsg(int t,Byte b1,Byte b2,Byte b3) : TimedMsg(t)
{
	m = gcnew MidiMsg(b1,b2,b3);
}
TimedMidiMsg(int t,int _m) : TimedMsg(t)
{
	m = gcnew MidiMsg(_m);
}

property bool IsMidi{ virtual bool get() override{ return true; } }
property bool IsMeta{ virtual bool get() override{ return false; } }

virtual String^ ToString() override
{
	return String::Concat(Time.ToString()," ",m->ToString());
}
};

/// <summary>
/// a class representing a midi meta message
/// </summary>
public ref class MetaMsg : public TimedMsg
{
	public:
	Byte Type;
	array<Byte>^ Data;
	MetaMsg(int t,Byte tp) : TimedMsg(t)
	{
		Type = tp;
		Data = gcnew array<Byte>(0);
}
MetaMsg(int t,Byte tp,array<Byte>^ d) : TimedMsg(t)
{
	Type = tp;
	Data = d;
}
MetaMsg(int t,Byte tp,String^ s) : TimedMsg(t)
{
	Type = tp;
	Txt = s;
}
property bool IsMidi{ virtual bool get() override{ return false; } }
property bool IsMeta{ virtual bool get() override{ return true; } }

property String^ Txt
{
	String^ get()
	{
		//if (Data == null) return "";
		ASCIIEncoding^ a = gcnew ASCIIEncoding();
		return a->GetString(Data);
}
void set(String^ value)
{
	ASCIIEncoding^ a = gcnew ASCIIEncoding();
	Data = a->GetBytes(value);
}
}

property unsigned int Int24{ unsigned int get(){ return (unsigned int)(Data[0]*0x10000+Data[1]*0x100+Data[2]); } }

String^ Description()
{
	String^ s = "";
	switch (Type)
	{
		case 0x00: s = "Sequence Nr: "; break;
		case 0x01: s = "Text: "; break;
		case 0x02: s = "Copyright: "; break;
		case 0x03: s = "Track Name: "; break;
		case 0x04: s = "Instrument Name: "; break;
		case 0x05: s = "Lyrics: "; break;
		case 0x06: s = "Marker: "; break;
		case 0x07: s = "Cue Point: "; break;
		case 0x20: s = "Channel Prefix: "; break;
		case 0x21: s = "Port Prefix: "; break;
		case 0x2F: s = "End Of Track"; break;
		case 0x51: s = "Tempo: "; break;
		case 0x54: s = "SMPTE Offset: "; break;
		case 0x58: s = "Time Signature: "; break;
		case 0x59: s = "Key Signature: "; break;
		default: s = String::Concat("#",Type.ToString(),": "); break;
}
return s;
}
String^ ValueString()
{
	String^ s = "";
	switch (Type)
	{
		case 0x20:
		case 0x21:
		s = Data[0].ToString(); break;
		case 0x51:
		s = Int24.ToString(); break;
		case 0x54:
		for (int i = 0;i<Data->Length;i++)
		s = String::Concat(s,Data[i].ToString()," ");
		break;
		case 0x58:
		s = String::Concat(Data[0].ToString(),"/",Math::Pow(2,Data[1]).ToString()," (");
		for (int i = 0;i<Data->Length;i++)
		s = String::Concat(s,Data[i].ToString()," ");
		s = String::Concat(s,")");
		break;
		case 0x59:
		if (Data[1] == 1) s = KeyName(((SByte)Data[0])*7+69)->ToLower();
		else s = KeyName(((SByte)Data[0])*7+60);
		s = String::Concat(s," (",((signed char)Data[0]).ToString(),";",Data[1].ToString(),")");
		break;
		default: s = Txt; break;
}
return s;
}
virtual String^ ToString() override
{
	return String::Concat(Time.ToString()," Meta ",Description(),ValueString());
}
private:
String^ KeyName(int note)
{
	switch (note%12)
	{
		case 0: return "C";
		case 1: return "C#";
		case 2: return "D";
		case 3: return "D#";
		case 4: return "E";
		case 5: return "F";
		case 6: return "F#";
		case 7: return "G";
		case 8: return "G#";
		case 9: return "A";
		case 10: return "A#";
		case 11: return "B";
		default: return "";
}
}
};

public ref class TimedSysExMsg : public TimedMsg
{
	public:
	TimedSysExMsg(int t,array<Byte>^ b) : TimedMsg(t)
	{
		data = b;
}

property bool IsMidi{ virtual bool get() override{ return false; } }
property bool IsMeta{ virtual bool get() override{ return false; } }

virtual String^ ToString() override
{
	String ^s = data[0].ToString("X2");
	for (int i = 1;i<data->Length;i++)
	s = String::Concat(s,".",data[i].ToString("X2"));
	return String::Concat(Time.ToString()," SysEx: ",s);
}
private:
array<Byte>^ data;
};

/// <summary>
/// a class representing a track in a midi file
/// as a list of events (+ meta data)
/// </summary>
public ref class MidiTrack
{
	public:
	MidiTrack()
	{
		events = gcnew ArrayList();
		enabled = true;
}
property TimedMsg^ e[int]{ TimedMsg^ get(int index){ return dynamic_cast<TimedMsg^>(events->default[index]); } }


ArrayList^ events;
unsigned int size;
String^ name;
bool enabled;
};

/// <summary>
/// base class for chords & intervals
/// contains timing info (start time and duration im midi ticks)
/// </summary>
public ref class TimeInfo abstract
{
	public:
	int Time,Duration;
	bool Add;
	TimeInfo(int t,int d,bool a)
	{
		Time = t;
		Duration = d;
		Add = a;
}
property String^ Name{ virtual String^ get() abstract; }
property bool IsChord{ virtual bool get() abstract; }
};

/// <summary>
/// a class that contains three midi keys that represent a chord
/// and can determine the chord's quality is in a particular tuning scheme
/// </summary>
public ref class Chord : public TimeInfo
{
	public:
	Byte fundamental,third,fifth;
	Chord(Byte k1,Byte k2,Byte k3,bool a) : TimeInfo(0,0,a)
	{
		fundamental = k1;
		third = k2;
		fifth = k3;
}
property bool IsMajor{ bool get(){ return ((third-fundamental+120)%12 == 4); } }
property bool IsMinor{ bool get(){ return ((third-fundamental+120)%12 == 3); } }

property String^ Name
{
	virtual String^ get() override
	{
		switch((third-fundamental+120)%12)
		{
			case 3: return ChordName(fundamental)->ToLower();
			case 4: return ChordName(fundamental);
			default: return "?";
}
}
}

property bool IsChord{ virtual bool get() override{ return true; } }

static String^ ChordName(int note)
{
	switch (note%12)
	{
		case 0: return "C";
		case 1: return "C#";
		case 2: return "D";
		case 3: return "D#";
		case 4: return "E";
		case 5: return "F";
		case 6: return "F#";
		case 7: return "G";
		case 8: return "G#";
		case 9: return "A";
		case 10: return "A#";
		case 11: return "B";
		default: return "";
}
}
};

public ref class Interval : public TimeInfo
{
	public:
	Byte lower,upper;
	Interval(Byte k1,Byte k2,bool a) : TimeInfo(0,0,a)
	{
		lower = Math::Min(k1,k2);
		upper = Math::Max(k1,k2);
}

property String^ Name
{
	virtual String^ get() override
	{
		String^ s = Chord::ChordName(lower);
		switch ((upper-lower)%12)
		{
			case 1: return String::Concat("2",s->ToLower());
			case 2: return String::Concat("2",s);
			case 3: return String::Concat("3",s->ToLower());
			case 4: return String::Concat("3",s);
			case 5: return String::Concat("4",s);
			case 6: return String::Concat("t",s);
			case 7: return String::Concat("5",s);
			case 8: return String::Concat("6",s->ToLower());
			case 9: return String::Concat("6",s);
			case 10: return String::Concat("7",s->ToLower());
			case 11: return String::Concat("7",s);
			default: return String::Concat("-",s);
}
}
}

property bool IsChord{ virtual bool get() override{ return false; } }
};

/// <summary>
/// a class which contains a list of keys
/// and makes it possible to determine if these keys contain a chord
/// </summary>
public ref class KeyList : public ArrayList
{
	public:
	KeyList()
	{
}
KeyList(KeyList^ k)
{
	AddRange(k);
}

property Byte k[int]{ Byte get(int index){ return (Byte)default[index]; } }

void Update(MidiMsg^ m)
{
	Object^ obj = m->Byte2;
	if (m->IsNoteOn && !Contains(obj))
	Add(obj);
	else if (m->IsNoteOff)
	Remove(obj);
}
TimeInfo^ FindChord()
{
	KeyList^ reduced = Reduce();
	if (reduced->Count<2) return nullptr;
	// find interval
	if (reduced->Count == 2)
	switch (Math::Abs(reduced->k[0]-reduced->k[1])%12)
	{
		case 3: case 4: case 5: case 7: case 8: case 9:
		return gcnew Interval(reduced->k[0],reduced->k[1],false);
		default:
		return nullptr;
}
// find chord
for (int i = 0;i<reduced->Count;i++)
{
	Byte k = reduced->k[i];
	int fifth = -1,major = -1,minor = -1;
	for (int j = 0;j<reduced->Count;j++)
	{
		Byte k2 = reduced->k[j];
		switch((k2-k+120)%12)
		{
			case 3: minor = k2; break;
			case 4: major = k2; break;
			case 7: fifth = k2; break;
}
if (fifth>-1)
{
	if (major>-1) return gcnew Chord(k,(Byte)major,(Byte)fifth,reduced->Count>3);
	if (minor>-1) return gcnew Chord(k,(Byte)minor,(Byte)fifth,reduced->Count>3);
}
}
}
// find fifth
for (int i = 0;i<reduced->Count;i++)
{
	Byte k = reduced->k[i];
	for (int j = 0;j<reduced->Count;j++)
	{
		Byte k2 = reduced->k[j];
		if (Math::Abs(k2-k)%12 == 7)
		return gcnew Interval(k,k2,true);
}
}
// find major third
for (int i = 0;i<reduced->Count;i++)
{
	Byte k = reduced->k[i];
	for (int j = 0;j<reduced->Count;j++)
	{
		Byte k2 = reduced->k[j];
		if (Math::Abs(k2-k)%12 == 4)
		return gcnew Interval(k,k2,true);
}
}
// find minor third
for (int i = 0;i<reduced->Count;i++)
{
	Byte k = reduced->k[i];
	for (int j = 0;j<reduced->Count;j++)
	{
		Byte k2 = reduced->k[j];
		if (Math::Abs(k2-k)%12 == 3)
		return gcnew Interval(k,k2,true);
}
}
// find fourth
for (int i = 0;i<reduced->Count;i++)
{
	Byte k = reduced->k[i];
	for (int j = 0;j<reduced->Count;j++)
	{
		Byte k2 = reduced->k[j];
		if (Math::Abs(k2-k)%12 == 5)
		return gcnew Interval(k,k2,true);
}
}
// find minor sixth
for (int i = 0;i<reduced->Count;i++)
{
	Byte k = reduced->k[i];
	for (int j = 0;j<reduced->Count;j++)
	{
		Byte k2 = reduced->k[j];
		if (Math::Abs(k2-k)%12 == 8)
		return gcnew Interval(k,k2,true);
}
}
// find major sixth
for (int i = 0;i<reduced->Count;i++)
{
	Byte k = reduced->k[i];
	for (int j = 0;j<reduced->Count;j++)
	{
		Byte k2 = reduced->k[j];
		if (Math::Abs(k2-k)%12 == 9)
		return gcnew Interval(k,k2,true);
}
}
return nullptr;
}
static String^ NoteName(int note)
{
	String^ s;
	switch (note%12)
	{
		case 0: s = "c"; break;
		case 1: s = "c#"; break;
		case 2: s = "d"; break;
		case 3: s = "d#"; break;
		case 4: s = "e"; break;
		case 5: s = "f"; break;
		case 6: s = "f#"; break;
		case 7: s = "g"; break;
		case 8: s = "g#"; break;
		case 9: s = "a"; break;
		case 10: s = "a#"; break;
		case 11: s = "b"; break;
		default: s = ""; break;
}
return String::Concat(s,(note/12).ToString());
}
private:
// removes double keys from list
KeyList^ Reduce()
{
	KeyList^ r = gcnew KeyList(this);
	for (int i = 0;i<r->Count;i++)
	for (int j = i+1;j<r->Count;j++)
	if (r->k[i]%12 == r->k[j]%12)
	{
		r->RemoveAt(j);
		j--;
}
return r;
}
};

/// <summary>
/// a class representing a midi file
/// (as a collection of several tracks of midi events)
/// </summary>
public ref class MidiFile
{
	public:
	String^ name;
	unsigned short timing; // standard: 480 ( = ticks per beat)
	unsigned short ticksperbeat;
	Byte framespersecond;
	Byte ticksperframe;
	array<MidiTrack^>^ tracks;
	ArrayList^ allevents;
	int bars;
	double tempo;
	int instrument;
	int transpose;
	Byte max_note,min_note;
	MetaMsg ^key_sig,^time_sig;
	MidiFile()
	{
		bars = 0;
		tempo = 120;
		instrument = -1;
		key_sig = nullptr;
		time_sig = nullptr;
		transpose = 0;
}
ArrayList^ FindChords()
{
	MergeTracks();
	ArrayList^ chords = gcnew ArrayList();
	KeyList^ PressedKeys = gcnew KeyList();
	TimeInfo ^chord = nullptr,^lastone = nullptr;
	int t;
	for (int i = 0;i<allevents->Count;i++)
	{
		if (!dynamic_cast<TimedMidiMsg^>(allevents->default[i])->m->IsNote) continue;
		t = dynamic_cast<TimedMidiMsg^>(allevents->default[i])->Time;
		PressedKeys->Update(dynamic_cast<TimedMidiMsg^>(allevents->default[i])->m);
		while ((i+1<allevents->Count) && (dynamic_cast<TimedMidiMsg^>(allevents->default[i+1])->Time == t))
		{
			i++;
			PressedKeys->Update(dynamic_cast<TimedMidiMsg^>(allevents->default[i])->m);
}
lastone = chord;
if ((chord = PressedKeys->FindChord()) != nullptr)
{
	chord->Time = t;
	if (chords->Count>0)
	{
		if ((chord->Name != dynamic_cast<TimeInfo^>(chords->default[chords->Count-1])->Name) && (dynamic_cast<TimeInfo^>(chords->default[chords->Count-1])->Duration == 0))
		dynamic_cast<TimeInfo^>(chords->default[chords->Count-1])->Duration = t-dynamic_cast<TimeInfo^>(chords->default[chords->Count-1])->Time;
}
if ((chords->Count == 0) || (lastone == nullptr) || (chord->Name != lastone->Name))
chords->Add(chord);
}
else if ((chords->Count>0) && (dynamic_cast<TimeInfo^>(chords->default[chords->Count-1])->Duration == 0))
dynamic_cast<TimeInfo^>(chords->default[chords->Count-1])->Duration = t-dynamic_cast<TimeInfo^>(chords->default[chords->Count-1])->Time;
}
// remove chords shorter than 1/64 bar
for (int i = 0;i<chords->Count;i++)
if (dynamic_cast<TimeInfo^>(chords->default[i])->Duration*16<timing)
{
	chords->RemoveAt(i);
	i--;
}
return chords;
}
void Transpose(int tr_new)
{
	int tr = tr_new-transpose;
	for (int k = 0;k<tracks->Length;k++)
	{
		MidiTrack^ t = tracks[k];
		for (int i = 0;i<t->events->Count;i++)
		if (t->e[i]->IsMidi)
		{
			TimedMidiMsg^ m = dynamic_cast<TimedMidiMsg^>(t->e[i]);
			if (m->m->IsNote)
			m->m->Byte2 += tr;
}
}
max_note += tr;
min_note += tr;
transpose = tr_new;
}
void InsertMarker(int tr,int t_start,int t_stop)
{
	MidiTrack^ t = tracks[tr];
	/*int i;
	for (i = 0;t->e[i]->Time<t_start;i++);
	if (t->e[i]->IsMidi)
		if (dynamic_cast<TimedMidiMsg^>(t->e[i])->m->IsNoteOff)
			i++;
	int time = t->e[i]->Time;
	t->events->Insert(i,gcnew MetaMsg(time,6,"start"));
	for (i = i;t->e[i]->Time <= t_stop;i++);
	if (t->e[i-1]->IsMidi)
		if (dynamic_cast<TimedMidiMsg^>(t->e[i-1])->m->IsNoteOn)
			i--;
	time = t->e[i]->Time;
	t->events->Insert(i,gcnew MetaMsg(time,6,"stop"));*/
	int i = 0;
	while (t->e[i]->Time<t_start)
	{
		i++;
}
int z;
for ( ;(i<t->events->Count) && (t->e[i]->Time <= t_stop);i++)
{
	if (t->e[i]->IsMidi)
	{
		if (dynamic_cast<TimedMidiMsg^>(t->e[i])->m->IsNoteOn)
		{
			int time = t->e[i]->Time;
			t->events->Insert(i,gcnew MetaMsg(time,6,"bold"));
			i++;
}
}
else if(t->e[i]->IsMeta)
{
	MetaMsg^ m = dynamic_cast<MetaMsg^>(t->e[i]);
	if (m->Type == 6)
	{
		t->events->RemoveAt(i);
}
}
z=i;
}
int time = t->e[z]->Time;
t->events->Insert(z,gcnew MetaMsg(time,6,"stop"));
}
void RemoveMarkers(int tr,int t_start,int t_stop)
{
	MidiTrack^ t = tracks[tr];
	bool started = false;
	int i = 0;
	while (t->e[i]->Time<t_start) i++;
	for ( ;(i<t->events->Count) && (t->e[i]->Time <= t_stop);i++)
	if (t->e[i]->IsMeta)
	{
		MetaMsg^ m = dynamic_cast<MetaMsg^>(t->e[i]);
		if (m->Type == 6)
		{
			/*if (m->Txt->ToLower()->Equals("start"))
			{
				t->events->RemoveAt(i);
				i--;
			}
			else if (m->Txt->ToLower()->Equals("stop"))
			{
				t->events->RemoveAt(i);
				i--;
			}*/
			t->events->RemoveAt(i);
			if(!started)
			{
				started = true;
				int time = t->e[i]->Time;
				t->events->Insert(i,gcnew MetaMsg(time,6,"stop"));
				i++;
}
i--;
}
}
}
void RemoveAllMarkers(int tr)
{
	int t_start = 0;
	int t_stop = bars*4*timing;
	RemoveMarkers(tr,t_start,t_stop);
}
private:

// merge all tracks into "allevents"
// (no meta msgs & instrument  changes)
// used for playback and chord finding
void MergeTracks()
{
	allevents = gcnew ArrayList();
	int j;
	for (int k = 0;k<tracks->Length;k++)
	{
		MidiTrack^ t = tracks[k];
		if (!t->enabled) continue;
		j = 0;
		for (int i = 0;i<t->events->Count;i++)
		if ((t->e[i]->IsMidi) && (!dynamic_cast<TimedMidiMsg^>(t->e[i])->m->IsProgramChange))
		{
			while ( (j<allevents->Count) && (dynamic_cast<TimedMidiMsg^>(allevents->default[j])->Time <= t->e[i]->Time) )
			j++;
			allevents->Insert(j,t->e[i]);
}
}
}
};

/// <summary>
/// a class for reading midi data from a file
/// </summary>
public ref class MidiFileReader
{
	public:
	String^ chunkid;
	unsigned int chunksz;
	unsigned short format;
	MidiFileReader()
	{
		runningstatus = 0;
}
MidiFile^ Read(String^ fn)
{
	mf = gcnew MidiFile();
	mf->name = fn;
	mf->max_note = 0;
	mf->min_note = 127;
	mf->tempo = 0;
	fs = File::OpenRead(fn);
	r = gcnew BinaryReader(fs);
	ReadHeader();
	s = 0;
	max_time = 0;
	for (int i = 0;i<mf->tracks->Length;i++)
	ReadNextTrack();
	r->Close();
	fs->Close();
	mf->max_note = (Byte)(((mf->max_note/12)+1)*12);
	mf->min_note = (Byte)((mf->min_note/12)*12);
	mf->bars = (int)Math::Ceiling(((double)max_time)/mf->timing/4);
	if (mf->tempo == 0) mf->tempo = 120;
	return mf;
}
private:
MidiFile^ mf;
FileStream^ fs;
BinaryReader^ r;
int s; // # tracks already read
int time; // cumulated time
int max_time;
Byte runningstatus;
void ReadHeader()
{
	chunkid = ReadString(4);
	chunksz = ReadInt32();
	format = ReadInt16();
	int numtracks = ReadInt16();
	mf->timing = ReadInt16();
	if ((mf->timing&0x0800) == 1)
	{
		mf->framespersecond = (Byte)(mf->timing&0x7F00);
		mf->ticksperframe = (Byte)(mf->timing&0x00FF);
}
else mf->ticksperbeat = mf->timing;
mf->tracks = gcnew array<MidiTrack^>(numtracks);
}
void ReadNextTrack()
{
	time = 0;
	if (ReadString(4)->Equals("MTrk"))
	{
		mf->tracks[s] = gcnew MidiTrack();
		mf->tracks[s]->size = ReadInt32();
		while (ReadNextEvent());
}
else MessageBox::Show("File Error");
max_time = Math::Max(time,max_time);
s++;
}
bool ReadNextEvent()
{
	int t = ReadVarLenInt();
	time += t;
	switch (PeekByte())
	{
		case 0xFF:
		return ReadMetaEvent();
		case 0xF0:
		case 0xF7:
		ReadSysExEvent();
		break;
		default:
		ReadMidiEvent();
		break;
}
return true;
}
void ReadMidiEvent()
{
	Byte b1,b2,b3 = 0;
	b1 = r->ReadByte();
	if (b1<0x80) // running status applies
	{
		b2 = b1;
		b1 = runningstatus;
}
else
{
	runningstatus = b1;
	b2 = r->ReadByte();
}
if (((b1&0xF0) != 0xC0) && ((b1&0xF0) != 0xD0))
b3 = r->ReadByte();
TimedMidiMsg^ m = gcnew TimedMidiMsg(time,b1,b2,b3);
if (m->m->IsNote)
{
	mf->min_note = Math::Min(mf->min_note,m->m->Byte2);
	mf->max_note = Math::Max(mf->max_note,m->m->Byte2);
}
if (m->m->IsProgramChange)
{
	if (mf->instrument<0) mf->instrument = m->m->Byte2;
}
mf->tracks[s]->events->Add(m);
}
bool ReadMetaEvent()
{
	Byte b = r->ReadByte();
	b = r->ReadByte();
	int l = ReadVarLenInt();
	array<Byte>^ ba = r->ReadBytes(l);
	MetaMsg^ m = gcnew MetaMsg(time,b,ba);
	mf->tracks[s]->events->Add(m);
	switch (b)
	{
		case 0x03: // track name
		mf->tracks[s]->name = m->Txt;
		break;
		case 0x2F: // end of track
		return false;
		case 0x51: // tempo
		if (mf->tempo == 0) mf->tempo = 60000000.0/m->Int24;
		break;
		case 0x58: // time signature
		if (mf->time_sig == nullptr) mf->time_sig = m;
		break;
		case 0x59: // key signature
		if (mf->key_sig == nullptr) mf->key_sig = m;
		break;
}
return true;
}
void ReadSysExEvent()
{
	Byte b = r->ReadByte();
	int l = ReadVarLenInt();
	array<Byte>^ ba = r->ReadBytes(l);
	mf->tracks[s]->events->Add(gcnew TimedSysExMsg(time,ba));
}
unsigned int ReadInt32() // read 4 bytes (big-endian: msb first)
{
	array<Byte>^ b = r->ReadBytes(4);
	return (unsigned int)(b[0]*0x1000000+b[1]*0x10000+b[2]*0x100+b[3]);
}
unsigned int ReadInt24() // read 3 bytes (big-endian: msb first)
{
	array<Byte>^ b = r->ReadBytes(3);
	return (unsigned int)(b[0]*0x10000+b[1]*0x100+b[2]);
}
unsigned short ReadInt16() // read 2 bytes (big-endian: msb first)
{
	array<Byte>^ b = r->ReadBytes(2);
	return (unsigned short)(b[0]*0x100+b[1]);
}
String^ ReadString(int l)
{
	ASCIIEncoding^ a = gcnew ASCIIEncoding();
	return a->GetString(r->ReadBytes(l));
}
int ReadVarLenInt()
{
	int v = 0;
	Byte b = r->ReadByte();
	v += (b&0x7F)*0x200000;
	if ((b&0x80) == 0) return v/0x200000;
	b = r->ReadByte();
	v += (b&0x7F)*0x4000;
	if ((b&0x80) == 0) return v/0x4000;
	b = r->ReadByte();
	v += (b&0x7F)*0x80;
	if ((b&0x80) == 0) return v/0x80;
	b = r->ReadByte();
	v += b&0x7F;
	return v;
}
Byte PeekByte()
{
	Byte b = (Byte)fs->ReadByte();
	fs->Seek(-1,SeekOrigin::Current);
	return b;
}
};

/// <summary>
/// a class for writing a midi data to a file
/// </summary>
public ref class MidiFileWriter
{
	public:
	MidiFileWriter()
	{
		runningstatus = 0;
}
void Write(MidiFile^ f,String^ name)
{
	mf = f;
	fs = File::OpenWrite(name);
	w = gcnew BinaryWriter(fs);
	WriteHeader();
	for (int i = 0;i<mf->tracks->Length;i++)
	WriteTrack(mf->tracks[i]);
	w->Close();
	fs->Close();
}
private:
MidiFile^ mf;
FileStream^ fs;
BinaryWriter^ w;
int time;
Byte runningstatus;
void WriteHeader()
{
	WriteString("MThd");
	unsigned int chunksz = 6;
	WriteInt32(chunksz);
	unsigned short format = 1;
	WriteInt16(format);
	WriteInt16((unsigned short)mf->tracks->Length);
	WriteInt16(mf->timing);
}
int CalculateTrackSize(MidiTrack^ tr)
{
	time = 0;
	runningstatus = 0;
	int s = 0;
	for (int i = 0;i<tr->events->Count;i++)
	s += GetSize(tr->e[i]);
	return s;
}
void WriteTrack(MidiTrack^ tr)
{
	WriteString("MTrk");
	TimedMsg^ lastevent = tr->e[tr->events->Count-1];
	if (!lastevent->IsMeta || dynamic_cast<MetaMsg^>(lastevent)->Type != 0x2F)
	tr->events->Add(gcnew MetaMsg(lastevent->Time,0x2F));
	tr->size = CalculateTrackSize(tr);
	WriteInt32(tr->size);
	time = 0;
	runningstatus = 0;
	for (int i = 0;i<tr->events->Count;i++)
	WriteEvent(tr->e[i]);
}
int GetSize(TimedMsg^ m)
{
	int s = 0;
	s += GetVarLenSize(m->Time-time);
	time = m->Time;
	if (m->IsMidi) s += GetSize(dynamic_cast<TimedMidiMsg^>(m)->m);
	else if (m->IsMeta) s += GetSize(dynamic_cast<MetaMsg^>(m));
	return s;
}
void WriteEvent(TimedMsg^ m)
{
	WriteVarLenInt(m->Time-time);
	time = m->Time;
	if (m->IsMidi) WriteMidiEvent(dynamic_cast<TimedMidiMsg^>(m)->m);
	else if (m->IsMeta) WriteMetaEvent(dynamic_cast<MetaMsg^>(m));
}
int GetSize(MidiMsg^ m)
{
	int s = 0;
	if (m->Byte1 != runningstatus)
	{
		s++;
		runningstatus = m->Byte1;
}
s++;
if (((m->Byte1&0xF0) != 0xC0) && ((m->Byte1&0xF0) != 0xD0))
s++;
return s;
}
void WriteMidiEvent(MidiMsg^ m)
{
	if (m->Byte1 != runningstatus)
	{
		w->Write(m->Byte1);
		runningstatus = m->Byte1;
}
w->Write(m->Byte2);
if (((m->Byte1&0xF0) != 0xC0) && ((m->Byte1&0xF0) != 0xD0))
w->Write(m->Byte3);
}
int GetSize(MetaMsg^ m)
{
	int s = 2;
	s += GetVarLenSize(m->Data->Length);
	s += m->Data->Length;
	return s;
}
void WriteMetaEvent(MetaMsg^ m)
{
	w->Write((Byte)0xFF);
	w->Write(m->Type);
	WriteVarLenInt(m->Data->Length);
	w->Write(m->Data);
}
void WriteInt32(unsigned int v)
{
	w->Write((Byte)(v/0x1000000));
	w->Write((Byte)((v/0x10000)&0xFF));
	w->Write((Byte)((v/0x100)&0xFF));
	w->Write((Byte)(v&0xFF));
}
void WriteInt24(unsigned int v)
{
	w->Write((Byte)((v/0x10000)&0xFF));
	w->Write((Byte)((v/0x100)&0xFF));
	w->Write((Byte)(v&0xFF));
}
void WriteInt16(unsigned short v)
{
	w->Write((Byte)((v/0x100)&0xFF));
	w->Write((Byte)(v&0xFF));
}
void WriteString(String^ s)
{
	ASCIIEncoding^ a = gcnew ASCIIEncoding();
	w->Write(a->GetBytes(s));
}
int GetVarLenSize(int v)
{
	Byte b1 = 0,b2 = 0,b3 = 0,b4 = 0;
	b1 = (Byte)(v&0x7F);
	v /= 0x80;
	if (v != 0) b2 |= 0x80;
	b2 |= (Byte)(v&0x7F);
	v /= 0x80;
	if (v != 0) b3 |= 0x80;
	b3 |= (Byte)(v&0x7F);
	v /= 0x80;
	if (v != 0) b4 |= 0x80;
	b4 |= (Byte)(v&0x7F);
	int s = 0;
	if (b4 != 0) s++;
	if (b3 != 0) s++;
	if (b2 != 0) s++;
	s++;
	return s;
}
void WriteVarLenInt(int v)
{
	Byte b1 = 0,b2 = 0,b3 = 0,b4 = 0;
	b1 = (Byte)(v&0x7F);
	v /= 0x80;
	if (v != 0) b2 |= 0x80;
	b2 |= (Byte)(v&0x7F);
	v /= 0x80;
	if (v != 0) b3 |= 0x80;
	b3 |= (Byte)(v&0x7F);
	v /= 0x80;
	if (v != 0) b4 |= 0x80;
	b4 |= (Byte)(v&0x7F);
	if (b4 != 0) w->Write(b4);
	if (b3 != 0) w->Write(b3);
	if (b2 != 0) w->Write(b2);
	w->Write(b1);
}
};

public ref class QualityWeights
{
	public:
	double fifth,fourth,M3,m3,M6,m6,Ch5,Ch3;
	double Add,Short,Threshold;
	QualityWeights()
	{
		fifth = 1;
		fourth = 1;
		M3 = 1;
		m3 = 1;
		M6 = 1;
		m6 = 1;
		Ch5 = 1;
		Ch3 = 1;
		Add = 1;
		Short = 1;
}
bool enabled(TimeInfo^ c)
{
	if (c->Add && Add == 0) return false;
	if (c->Duration<Threshold && Short == 0) return false;
	if (c->IsChord)
	return (Ch3>0 || Ch5>0);
	else
	{
		Interval^ itvl = dynamic_cast<Interval^>(c);
		switch ((itvl->upper-itvl->lower)%12)
		{
			case 3: return (m3>0);
			case 4: return (M3>0);
			case 5: return (fourth>0);
			case 7: return (fifth>0);
			case 8: return (m6>0);
			case 9: return (M6>0);
			default: return true;
}
}
}
};

/// <summary>
/// contains twelve numbers representing a particular tuning scheme
/// each number specifies a key's deviation in cents from equal tuning
/// (starting with c)
/// </summary>
public ref class TuningScheme
{
	protected:
	array<int>^ t;
	int transpose;
	public:
	String^ Name;
	bool enabled;
	TuningScheme()
	{
		Name = "Equal";
		transpose = 0;
		t = gcnew array<int>(12);
		enabled = true;
}
TuningScheme(String^ filename)
{
	t = gcnew array<int>(12);
	Name = Path::ChangeExtension(filename,nullptr);
	StreamReader^ sr = gcnew StreamReader(filename);
	for (int i = 0;i<12;i++)
	t[i] = Convert::ToInt32(sr->ReadLine());
	sr->Close();
}

property int T[int]
{
	int get(int index)
	{
		return t[(index-transpose+12)%12];
}
void set(int index,int value)
{
	t[(index-transpose+12)%12] = value;
}
}

void Export(String^ filename)
{
	StreamWriter^ sw = gcnew StreamWriter(filename);
	for (int i = 0;i<12;i++)
	sw->WriteLine(t[i].ToString());
	sw->Close();
}
virtual String^ ToString() override
{
	String^ s = String::Concat(Name,":\t");
	for (int i = 0;i<12;i++)
	s = String::Concat(s,"\t",(T[i]/10).ToString());
	return s;
}
double Quality(TimeInfo^ t,QualityWeights^ w)
{
	if (t->IsChord)
	return Quality(dynamic_cast<Chord^>(t),w);
	else return Quality(dynamic_cast<Interval^>(t),w);
}
double Quality(Interval^ i,QualityWeights^ w)
{
	int just[12] = {0,117,39,156,-137,-20,0,20,137,-156,-39,-117};
int interval = (i->upper-i->lower)%12;
if (w == nullptr) w = gcnew QualityWeights();
double s = Math::Abs(T[i->upper%12]-T[i->lower%12]-just[interval])/10.0;
if (i->Add) s *= w->Add;
if (i->Duration<w->Threshold) s *= w->Short;
switch ((i->upper-i->lower)%12)
{
	case 3: return w->m3*s;
	case 4: return w->M3*s;
	case 5: return w->fourth*s;
	case 7: return w->fifth*s;
	case 8: return w->m6*s;
	case 9: return w->M6*s;
	default: return s;
}
}
double Quality(Chord^ c,QualityWeights^ w)
{
	int just[] = {0,117,39,156,-137,-20,0,20,137,-156,-39,-117};
int interval = (c->fifth-c->fundamental+120)%12;
if (w == nullptr) w = gcnew QualityWeights();
double s = w->Ch5*Math::Abs(T[c->fifth%12]-T[c->fundamental%12]-just[interval]);
if (c->IsMajor)
{
	interval = (c->third-c->fundamental+120)%12;
	s += w->Ch3*Math::Abs(T[c->third%12]-T[c->fundamental%12]-just[interval]);
}
else if (c->IsMinor)
{
	interval = (c->fifth-c->third+120)%12;
	s += w->Ch3*Math::Abs(T[c->fifth%12]-T[c->third%12]-just[interval]);
}
if (c->Add) s *= w->Add;
if (c->Duration<w->Threshold) s *= w->Short;
return s/10.0;
}
double MaxQuality()
{
	double max = 0;
	Chord ^C,^c;
	for (Byte i = 0;i<12;i++)
	{
		C = gcnew Chord(i,(Byte)(i+4),(Byte)(i+7),false);
		c = gcnew Chord(i,(Byte)(i+3),(Byte)(i+7),false);
		double q = Quality(C,nullptr);
		if (q>max) max = q;
		q = Quality(c,nullptr);
		if (q>max) max = q;
}
return max;
}
double AvgQuality(ArrayList^ cl,QualityWeights^ w)
{
	double q = 0;
	int n = 0;
	for (int i = 0;i<cl->Count;i++)
	{
		TimeInfo^ c = dynamic_cast<TimeInfo^>(cl->default[i]);
		if (w->enabled(c))
		{
			q += Quality(c,w);
			n++;
}
}
return q/n;
}

property int Transpose
{
	int get()
	{
		return transpose;
}
void set(int value)
{
	transpose = value;
}
}
};

/*__gc public class TuningMsg : public SysExMsg
{
public:
	TuningMsg(TuningScheme* t) : SysExMsg(21)
	{
		Data[2] = 0x7F; // device ID: all devices
		Data[3] = 0x08; // midi tuning
		Data[4] = 0x08; // scale/octave tuning 1-byte form
		Data[5] = 0x00; // channel
		Data[6] = 0x00; // channel
		Data[7] = 0x00; // channel
		for (int i = 0;i<12;i++)
			Data[8+i] = t->T[i]/10+64;
	}
};*/

#define BUFSZ	50
#define NBUF	2

public ref class MidiFilePlayer
{
	protected:
	MidiFile^ file;
	MidiStream^ stream;
	int deviceID;
	int start_time,stop_time;
	array<MidiBuffer*>^ buf;
	// local variables for public properties
	TuningScheme^ tuning;
	int instrument;
	double tempo,volume;
	int t;
	void Out(int j)
	{
		int buf_start = start_time+j*file->timing;
		int buf_end = Math::Min(buf_start+file->timing,stop_time);
		int begin_index = 0,end_index = 0;
		for (int i = 0;i<file->allevents->Count;i++)
		{
			if (dynamic_cast<TimedMidiMsg^>(file->allevents->default[i])->Time<buf_start) begin_index = i+1;
			if (dynamic_cast<TimedMidiMsg^>(file->allevents->default[i])->Time<buf_end) end_index = i+1;
			else break;
}
int sz = end_index-begin_index;
if (sz>BUFSZ)
{
	MessageBox::Show("WARNING: playback buffer too small!");
	return;
}
MidiBuffer* b = buf[j%NBUF];
stream->Unprepare(b->Header);
TimedMidiMsg^ m;
for (int i = 0;i<sz;i++)
{
	b->Events[i].DeltaTime = dynamic_cast<TimedMidiMsg^>(file->allevents->default[begin_index+i])->Time-t;
	b->Events[i].StreamID = 0;
	m = gcnew TimedMidiMsg(dynamic_cast<TimedMidiMsg^>(file->allevents->default[begin_index+i]));
	ChannelReroute(m->m);
	b->Events[i].Event = m->m->Data;
	t = dynamic_cast<TimedMidiMsg^>(file->allevents->default[begin_index+i])->Time;
}
b->filled = sz;
stream->Out(b);
}
void Run()
{
	int evt = CreateEvent(0,0,0,nullptr);
	stream = MidiStream::Open(deviceID,evt);
	stream->TimeDiv = file->timing;
	stream->Tempo = tempo;
	stream->Volume = volume;
	buf = gcnew array<MidiBuffer*>(NBUF);
	for (int i = 0;i<NBUF;i++)
	buf[i] = new MidiBuffer(BUFSZ);
	MidiBuffer *pb = new MidiBuffer(12);
	// init instrument
	for (int i = 0;i<12;i++)
	{
		pb->Events[i].DeltaTime = 0;
		pb->Events[i].StreamID = 0;
		pb->Events[i].Event = (gcnew ProgramChangeMsg(NewChannel(i),instrument))->Data;
}
stream->Out(pb);
//
t = start_time;
Out(0);
stream->Start();
Tuning = tuning;
ResetEvent(evt);
int j = 1;
while ((!stream->Stopped) && (j*file->timing<stop_time-start_time))
{
	Out(j);
	Wait(evt);
	j++;
}
stream->Unprepare(pb->Header);
delete pb;
Wait(evt);
Wait(evt);
//for (int i = 0;i<NBUF;i++) stream->Unprepare(&buf[i]);
delete[] buf;
delete buf;
stream->Close();
stream = nullptr;
CloseHandle(evt);
}
void Wait(int evt)
{
	while (!stream->Stopped)
	if (WaitForSingleObject(evt,100) == WAIT::OBJECT_0) return;
}
public:
MidiFilePlayer(MidiFile^ f)
{
	file = f;
	stream = nullptr;
	deviceID = 0;
	tuning = gcnew TuningScheme();
	instrument = 0;
	tempo = 120;
	volume = 1;
}
// play whole file
void Play(int dev)
{
	Play(dev,0,file->bars);
}
// play selected part (start & stop in bars)
void Play(int dev,double start,double stop)
{
	start_time = (int)(start*4*file->timing);
	stop_time = (int)(stop*4*file->timing);
	if (stream == nullptr)
	{
		deviceID = dev;
		Thread^ playthread = gcnew Thread(gcnew ThreadStart(this,&MidiFilePlayer::Run));
		playthread->Start();
}
else stream->Start();
}
void Pause()
{
	stream->Pause();
}
void Stop()
{
	if (stream != nullptr)
	{
		stream->Stop();
}
}

property double Position // position of the playback cursor in the file (in bars)
{
	double get()
	{
		if (stream != nullptr)
		{
			if ((start_time>0) || (stop_time<file->bars*4*file->timing))
			return (start_time+stream->Position)/4.0/file->timing;
			else return stream->Position/4.0/file->timing;
}
else return -1;
}
}

property double Volume
{
	double get()
	{
		if (stream != nullptr) volume = stream->Volume;
		return volume;
}
void set(double value)
{
	volume = value;
	if (stream != nullptr) stream->Volume = volume;
}
}

property TuningScheme^ Tuning
{
	void set(TuningScheme^ value)
	{
		tuning = value;
		if (stream == nullptr) return;
		for (int i = 0;i<12;i++)
		stream->ShortMsg(gcnew PitchWheelMsg(NewChannel(i),tuning->T[i]));
}
}

property int Instrument
{
	void set(int value)
	{
		instrument = value;
		if (stream == nullptr) return;
		for (int i = 0;i<12;i++)
		stream->ShortMsg(gcnew ProgramChangeMsg(NewChannel(i),instrument));
}
}

property double Tempo
{
	double get()
	{
		if (stream != nullptr) tempo = stream->Tempo;
		return tempo;
}
void set(double value)
{
	tempo = value;
	if (stream != nullptr) stream->Tempo = tempo;
}
}
private:
void ChannelReroute(MidiMsg^ m)
{
	if ((m->Opcode == 8) || (m->Opcode == 9))
	m->Byte1 = (Byte)(m->Opcode*0x10+NewChannel(m->Byte2));
}
int NewChannel(int NoteValue)
{
	int SkippedChannel = 9;
	int ch = NoteValue%12;
	if (ch >= SkippedChannel) ch++;
	return ch;
}
};
}

namespace Misc
{

	[DllImport("shell32.dll")] extern "C" int ShellExecute(int Handle,String^ Operation,String^ File,String^ Parameters,String^ Directory,int ShowCmd);

	public ref class SW
	{
		public:
		static const int HIDE = 0;
		static const int SHOWNORMAL = 1;
		static const int SHOWMINIMIZED = 2;
		static const int SHOWMAXIMIZED = 3;
		static const int SHOWNOACTIVATE = 4;
		static const int SHOW = 5;
		static const int MINIMZE = 6;
		static const int SHOWMINNOACTIVE = 7;
		static const int SHOWNA = 8;
		static const int RESTORE = 9;
		static const int SHOWDEFAULT = 10;
		static const int FORCEMINIMZE = 11;
		static const int MAX = 12;
};

public ref class Shell
{
	public:
	static void Execute(String^ file)
	{
		ShellExecute(0,nullptr,file,nullptr,nullptr,SW::SHOW);
}
};

}
}
