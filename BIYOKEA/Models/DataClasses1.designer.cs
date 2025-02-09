﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BIYOKEA.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="myphamthiennhien")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCTloaiSP(CTloaiSP instance);
    partial void UpdateCTloaiSP(CTloaiSP instance);
    partial void DeleteCTloaiSP(CTloaiSP instance);
    partial void InsertHoaDon(HoaDon instance);
    partial void UpdateHoaDon(HoaDon instance);
    partial void DeleteHoaDon(HoaDon instance);
    partial void InsertLoaiSP(LoaiSP instance);
    partial void UpdateLoaiSP(LoaiSP instance);
    partial void DeleteLoaiSP(LoaiSP instance);
    partial void InsertNguoiDung(NguoiDung instance);
    partial void UpdateNguoiDung(NguoiDung instance);
    partial void DeleteNguoiDung(NguoiDung instance);
    partial void InsertSanPham(SanPham instance);
    partial void UpdateSanPham(SanPham instance);
    partial void DeleteSanPham(SanPham instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["myphamthiennhienConnectionString2"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CTloaiSP> CTloaiSPs
		{
			get
			{
				return this.GetTable<CTloaiSP>();
			}
		}
		
		public System.Data.Linq.Table<HoaDon> HoaDons
		{
			get
			{
				return this.GetTable<HoaDon>();
			}
		}
		
		public System.Data.Linq.Table<LoaiSP> LoaiSPs
		{
			get
			{
				return this.GetTable<LoaiSP>();
			}
		}
		
		public System.Data.Linq.Table<NguoiDung> NguoiDungs
		{
			get
			{
				return this.GetTable<NguoiDung>();
			}
		}
		
		public System.Data.Linq.Table<SanPham> SanPhams
		{
			get
			{
				return this.GetTable<SanPham>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CTloaiSP")]
	public partial class CTloaiSP : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _maCTloai;
		
		private System.Nullable<int> _maLoai;
		
		private string _tenCTloai;
		
		private EntitySet<SanPham> _SanPhams;
		
		private EntityRef<LoaiSP> _LoaiSP;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmaCTloaiChanging(int value);
    partial void OnmaCTloaiChanged();
    partial void OnmaLoaiChanging(System.Nullable<int> value);
    partial void OnmaLoaiChanged();
    partial void OntenCTloaiChanging(string value);
    partial void OntenCTloaiChanged();
    #endregion
		
		public CTloaiSP()
		{
			this._SanPhams = new EntitySet<SanPham>(new Action<SanPham>(this.attach_SanPhams), new Action<SanPham>(this.detach_SanPhams));
			this._LoaiSP = default(EntityRef<LoaiSP>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maCTloai", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int maCTloai
		{
			get
			{
				return this._maCTloai;
			}
			set
			{
				if ((this._maCTloai != value))
				{
					this.OnmaCTloaiChanging(value);
					this.SendPropertyChanging();
					this._maCTloai = value;
					this.SendPropertyChanged("maCTloai");
					this.OnmaCTloaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maLoai", DbType="Int")]
		public System.Nullable<int> maLoai
		{
			get
			{
				return this._maLoai;
			}
			set
			{
				if ((this._maLoai != value))
				{
					if (this._LoaiSP.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnmaLoaiChanging(value);
					this.SendPropertyChanging();
					this._maLoai = value;
					this.SendPropertyChanged("maLoai");
					this.OnmaLoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tenCTloai", DbType="NVarChar(30)")]
		public string tenCTloai
		{
			get
			{
				return this._tenCTloai;
			}
			set
			{
				if ((this._tenCTloai != value))
				{
					this.OntenCTloaiChanging(value);
					this.SendPropertyChanging();
					this._tenCTloai = value;
					this.SendPropertyChanged("tenCTloai");
					this.OntenCTloaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CTloaiSP_SanPham", Storage="_SanPhams", ThisKey="maCTloai", OtherKey="maCTloai")]
		public EntitySet<SanPham> SanPhams
		{
			get
			{
				return this._SanPhams;
			}
			set
			{
				this._SanPhams.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LoaiSP_CTloaiSP", Storage="_LoaiSP", ThisKey="maLoai", OtherKey="maLoai", IsForeignKey=true)]
		public LoaiSP LoaiSP
		{
			get
			{
				return this._LoaiSP.Entity;
			}
			set
			{
				LoaiSP previousValue = this._LoaiSP.Entity;
				if (((previousValue != value) 
							|| (this._LoaiSP.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._LoaiSP.Entity = null;
						previousValue.CTloaiSPs.Remove(this);
					}
					this._LoaiSP.Entity = value;
					if ((value != null))
					{
						value.CTloaiSPs.Add(this);
						this._maLoai = value.maLoai;
					}
					else
					{
						this._maLoai = default(Nullable<int>);
					}
					this.SendPropertyChanged("LoaiSP");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_SanPhams(SanPham entity)
		{
			this.SendPropertyChanging();
			entity.CTloaiSP = this;
		}
		
		private void detach_SanPhams(SanPham entity)
		{
			this.SendPropertyChanging();
			entity.CTloaiSP = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.HoaDon")]
	public partial class HoaDon : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _maHD;
		
		private System.Nullable<int> _maND;
		
		private System.Nullable<int> _maSP;
		
		private string _diaChi;
		
		private System.Nullable<int> _soLuongBan;
		
		private System.Nullable<bool> _trangThai;
		
		private System.Nullable<System.DateTime> _ngayTL;
		
		private System.Nullable<bool> _xacNhan;
		
		private EntityRef<NguoiDung> _NguoiDung;
		
		private EntityRef<SanPham> _SanPham;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmaHDChanging(int value);
    partial void OnmaHDChanged();
    partial void OnmaNDChanging(System.Nullable<int> value);
    partial void OnmaNDChanged();
    partial void OnmaSPChanging(System.Nullable<int> value);
    partial void OnmaSPChanged();
    partial void OndiaChiChanging(string value);
    partial void OndiaChiChanged();
    partial void OnsoLuongBanChanging(System.Nullable<int> value);
    partial void OnsoLuongBanChanged();
    partial void OntrangThaiChanging(System.Nullable<bool> value);
    partial void OntrangThaiChanged();
    partial void OnngayTLChanging(System.Nullable<System.DateTime> value);
    partial void OnngayTLChanged();
    partial void OnxacNhanChanging(System.Nullable<bool> value);
    partial void OnxacNhanChanged();
    #endregion
		
		public HoaDon()
		{
			this._NguoiDung = default(EntityRef<NguoiDung>);
			this._SanPham = default(EntityRef<SanPham>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maHD", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int maHD
		{
			get
			{
				return this._maHD;
			}
			set
			{
				if ((this._maHD != value))
				{
					this.OnmaHDChanging(value);
					this.SendPropertyChanging();
					this._maHD = value;
					this.SendPropertyChanged("maHD");
					this.OnmaHDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maND", DbType="Int")]
		public System.Nullable<int> maND
		{
			get
			{
				return this._maND;
			}
			set
			{
				if ((this._maND != value))
				{
					if (this._NguoiDung.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnmaNDChanging(value);
					this.SendPropertyChanging();
					this._maND = value;
					this.SendPropertyChanged("maND");
					this.OnmaNDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maSP", DbType="Int")]
		public System.Nullable<int> maSP
		{
			get
			{
				return this._maSP;
			}
			set
			{
				if ((this._maSP != value))
				{
					if (this._SanPham.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnmaSPChanging(value);
					this.SendPropertyChanging();
					this._maSP = value;
					this.SendPropertyChanged("maSP");
					this.OnmaSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_diaChi", DbType="NVarChar(100)")]
		public string diaChi
		{
			get
			{
				return this._diaChi;
			}
			set
			{
				if ((this._diaChi != value))
				{
					this.OndiaChiChanging(value);
					this.SendPropertyChanging();
					this._diaChi = value;
					this.SendPropertyChanged("diaChi");
					this.OndiaChiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_soLuongBan", DbType="Int")]
		public System.Nullable<int> soLuongBan
		{
			get
			{
				return this._soLuongBan;
			}
			set
			{
				if ((this._soLuongBan != value))
				{
					this.OnsoLuongBanChanging(value);
					this.SendPropertyChanging();
					this._soLuongBan = value;
					this.SendPropertyChanged("soLuongBan");
					this.OnsoLuongBanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_trangThai", DbType="Bit")]
		public System.Nullable<bool> trangThai
		{
			get
			{
				return this._trangThai;
			}
			set
			{
				if ((this._trangThai != value))
				{
					this.OntrangThaiChanging(value);
					this.SendPropertyChanging();
					this._trangThai = value;
					this.SendPropertyChanged("trangThai");
					this.OntrangThaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngayTL", DbType="Date")]
		public System.Nullable<System.DateTime> ngayTL
		{
			get
			{
				return this._ngayTL;
			}
			set
			{
				if ((this._ngayTL != value))
				{
					this.OnngayTLChanging(value);
					this.SendPropertyChanging();
					this._ngayTL = value;
					this.SendPropertyChanged("ngayTL");
					this.OnngayTLChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_xacNhan", DbType="Bit")]
		public System.Nullable<bool> xacNhan
		{
			get
			{
				return this._xacNhan;
			}
			set
			{
				if ((this._xacNhan != value))
				{
					this.OnxacNhanChanging(value);
					this.SendPropertyChanging();
					this._xacNhan = value;
					this.SendPropertyChanged("xacNhan");
					this.OnxacNhanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="NguoiDung_HoaDon", Storage="_NguoiDung", ThisKey="maND", OtherKey="maND", IsForeignKey=true)]
		public NguoiDung NguoiDung
		{
			get
			{
				return this._NguoiDung.Entity;
			}
			set
			{
				NguoiDung previousValue = this._NguoiDung.Entity;
				if (((previousValue != value) 
							|| (this._NguoiDung.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._NguoiDung.Entity = null;
						previousValue.HoaDons.Remove(this);
					}
					this._NguoiDung.Entity = value;
					if ((value != null))
					{
						value.HoaDons.Add(this);
						this._maND = value.maND;
					}
					else
					{
						this._maND = default(Nullable<int>);
					}
					this.SendPropertyChanged("NguoiDung");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="SanPham_HoaDon", Storage="_SanPham", ThisKey="maSP", OtherKey="maSP", IsForeignKey=true)]
		public SanPham SanPham
		{
			get
			{
				return this._SanPham.Entity;
			}
			set
			{
				SanPham previousValue = this._SanPham.Entity;
				if (((previousValue != value) 
							|| (this._SanPham.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._SanPham.Entity = null;
						previousValue.HoaDons.Remove(this);
					}
					this._SanPham.Entity = value;
					if ((value != null))
					{
						value.HoaDons.Add(this);
						this._maSP = value.maSP;
					}
					else
					{
						this._maSP = default(Nullable<int>);
					}
					this.SendPropertyChanged("SanPham");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LoaiSP")]
	public partial class LoaiSP : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _maLoai;
		
		private string _tenLoai;
		
		private EntitySet<CTloaiSP> _CTloaiSPs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmaLoaiChanging(int value);
    partial void OnmaLoaiChanged();
    partial void OntenLoaiChanging(string value);
    partial void OntenLoaiChanged();
    #endregion
		
		public LoaiSP()
		{
			this._CTloaiSPs = new EntitySet<CTloaiSP>(new Action<CTloaiSP>(this.attach_CTloaiSPs), new Action<CTloaiSP>(this.detach_CTloaiSPs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maLoai", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int maLoai
		{
			get
			{
				return this._maLoai;
			}
			set
			{
				if ((this._maLoai != value))
				{
					this.OnmaLoaiChanging(value);
					this.SendPropertyChanging();
					this._maLoai = value;
					this.SendPropertyChanged("maLoai");
					this.OnmaLoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tenLoai", DbType="NVarChar(30)")]
		public string tenLoai
		{
			get
			{
				return this._tenLoai;
			}
			set
			{
				if ((this._tenLoai != value))
				{
					this.OntenLoaiChanging(value);
					this.SendPropertyChanging();
					this._tenLoai = value;
					this.SendPropertyChanged("tenLoai");
					this.OntenLoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LoaiSP_CTloaiSP", Storage="_CTloaiSPs", ThisKey="maLoai", OtherKey="maLoai")]
		public EntitySet<CTloaiSP> CTloaiSPs
		{
			get
			{
				return this._CTloaiSPs;
			}
			set
			{
				this._CTloaiSPs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_CTloaiSPs(CTloaiSP entity)
		{
			this.SendPropertyChanging();
			entity.LoaiSP = this;
		}
		
		private void detach_CTloaiSPs(CTloaiSP entity)
		{
			this.SendPropertyChanging();
			entity.LoaiSP = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.NguoiDung")]
	public partial class NguoiDung : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _maND;
		
		private string _tenND;
		
		private string _email;
		
		private string _matKhau;
		
		private string _sdt;
		
		private string _diaChi;
		
		private string _quyen;
		
		private EntitySet<HoaDon> _HoaDons;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmaNDChanging(int value);
    partial void OnmaNDChanged();
    partial void OntenNDChanging(string value);
    partial void OntenNDChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnmatKhauChanging(string value);
    partial void OnmatKhauChanged();
    partial void OnsdtChanging(string value);
    partial void OnsdtChanged();
    partial void OndiaChiChanging(string value);
    partial void OndiaChiChanged();
    partial void OnquyenChanging(string value);
    partial void OnquyenChanged();
    #endregion
		
		public NguoiDung()
		{
			this._HoaDons = new EntitySet<HoaDon>(new Action<HoaDon>(this.attach_HoaDons), new Action<HoaDon>(this.detach_HoaDons));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maND", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int maND
		{
			get
			{
				return this._maND;
			}
			set
			{
				if ((this._maND != value))
				{
					this.OnmaNDChanging(value);
					this.SendPropertyChanging();
					this._maND = value;
					this.SendPropertyChanged("maND");
					this.OnmaNDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tenND", DbType="NVarChar(30)")]
		public string tenND
		{
			get
			{
				return this._tenND;
			}
			set
			{
				if ((this._tenND != value))
				{
					this.OntenNDChanging(value);
					this.SendPropertyChanging();
					this._tenND = value;
					this.SendPropertyChanged("tenND");
					this.OntenNDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="NVarChar(99)")]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_matKhau", DbType="NVarChar(30)")]
		public string matKhau
		{
			get
			{
				return this._matKhau;
			}
			set
			{
				if ((this._matKhau != value))
				{
					this.OnmatKhauChanging(value);
					this.SendPropertyChanging();
					this._matKhau = value;
					this.SendPropertyChanged("matKhau");
					this.OnmatKhauChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sdt", DbType="NVarChar(10)")]
		public string sdt
		{
			get
			{
				return this._sdt;
			}
			set
			{
				if ((this._sdt != value))
				{
					this.OnsdtChanging(value);
					this.SendPropertyChanging();
					this._sdt = value;
					this.SendPropertyChanged("sdt");
					this.OnsdtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_diaChi", DbType="NVarChar(100)")]
		public string diaChi
		{
			get
			{
				return this._diaChi;
			}
			set
			{
				if ((this._diaChi != value))
				{
					this.OndiaChiChanging(value);
					this.SendPropertyChanging();
					this._diaChi = value;
					this.SendPropertyChanged("diaChi");
					this.OndiaChiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_quyen", DbType="NVarChar(10)")]
		public string quyen
		{
			get
			{
				return this._quyen;
			}
			set
			{
				if ((this._quyen != value))
				{
					this.OnquyenChanging(value);
					this.SendPropertyChanging();
					this._quyen = value;
					this.SendPropertyChanged("quyen");
					this.OnquyenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="NguoiDung_HoaDon", Storage="_HoaDons", ThisKey="maND", OtherKey="maND")]
		public EntitySet<HoaDon> HoaDons
		{
			get
			{
				return this._HoaDons;
			}
			set
			{
				this._HoaDons.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_HoaDons(HoaDon entity)
		{
			this.SendPropertyChanging();
			entity.NguoiDung = this;
		}
		
		private void detach_HoaDons(HoaDon entity)
		{
			this.SendPropertyChanging();
			entity.NguoiDung = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SanPham")]
	public partial class SanPham : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _maSP;
		
		private System.Nullable<int> _maCTloai;
		
		private System.Nullable<decimal> _gia;
		
		private string _photoURL;
		
		private System.Nullable<int> _soLuong;
		
		private string _tenSP;
		
		private string _chiTiet;
		
		private System.Nullable<System.DateTime> _ngayThem;
		
		private EntitySet<HoaDon> _HoaDons;
		
		private EntityRef<CTloaiSP> _CTloaiSP;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmaSPChanging(int value);
    partial void OnmaSPChanged();
    partial void OnmaCTloaiChanging(System.Nullable<int> value);
    partial void OnmaCTloaiChanged();
    partial void OngiaChanging(System.Nullable<decimal> value);
    partial void OngiaChanged();
    partial void OnphotoURLChanging(string value);
    partial void OnphotoURLChanged();
    partial void OnsoLuongChanging(System.Nullable<int> value);
    partial void OnsoLuongChanged();
    partial void OntenSPChanging(string value);
    partial void OntenSPChanged();
    partial void OnchiTietChanging(string value);
    partial void OnchiTietChanged();
    partial void OnngayThemChanging(System.Nullable<System.DateTime> value);
    partial void OnngayThemChanged();
    #endregion
		
		public SanPham()
		{
			this._HoaDons = new EntitySet<HoaDon>(new Action<HoaDon>(this.attach_HoaDons), new Action<HoaDon>(this.detach_HoaDons));
			this._CTloaiSP = default(EntityRef<CTloaiSP>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maSP", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int maSP
		{
			get
			{
				return this._maSP;
			}
			set
			{
				if ((this._maSP != value))
				{
					this.OnmaSPChanging(value);
					this.SendPropertyChanging();
					this._maSP = value;
					this.SendPropertyChanged("maSP");
					this.OnmaSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maCTloai", DbType="Int")]
		public System.Nullable<int> maCTloai
		{
			get
			{
				return this._maCTloai;
			}
			set
			{
				if ((this._maCTloai != value))
				{
					if (this._CTloaiSP.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnmaCTloaiChanging(value);
					this.SendPropertyChanging();
					this._maCTloai = value;
					this.SendPropertyChanged("maCTloai");
					this.OnmaCTloaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gia", DbType="Money")]
		public System.Nullable<decimal> gia
		{
			get
			{
				return this._gia;
			}
			set
			{
				if ((this._gia != value))
				{
					this.OngiaChanging(value);
					this.SendPropertyChanging();
					this._gia = value;
					this.SendPropertyChanged("gia");
					this.OngiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_photoURL", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string photoURL
		{
			get
			{
				return this._photoURL;
			}
			set
			{
				if ((this._photoURL != value))
				{
					this.OnphotoURLChanging(value);
					this.SendPropertyChanging();
					this._photoURL = value;
					this.SendPropertyChanged("photoURL");
					this.OnphotoURLChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_soLuong", DbType="Int")]
		public System.Nullable<int> soLuong
		{
			get
			{
				return this._soLuong;
			}
			set
			{
				if ((this._soLuong != value))
				{
					this.OnsoLuongChanging(value);
					this.SendPropertyChanging();
					this._soLuong = value;
					this.SendPropertyChanged("soLuong");
					this.OnsoLuongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tenSP", DbType="NVarChar(30)")]
		public string tenSP
		{
			get
			{
				return this._tenSP;
			}
			set
			{
				if ((this._tenSP != value))
				{
					this.OntenSPChanging(value);
					this.SendPropertyChanging();
					this._tenSP = value;
					this.SendPropertyChanged("tenSP");
					this.OntenSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_chiTiet", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string chiTiet
		{
			get
			{
				return this._chiTiet;
			}
			set
			{
				if ((this._chiTiet != value))
				{
					this.OnchiTietChanging(value);
					this.SendPropertyChanging();
					this._chiTiet = value;
					this.SendPropertyChanged("chiTiet");
					this.OnchiTietChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngayThem", DbType="Date")]
		public System.Nullable<System.DateTime> ngayThem
		{
			get
			{
				return this._ngayThem;
			}
			set
			{
				if ((this._ngayThem != value))
				{
					this.OnngayThemChanging(value);
					this.SendPropertyChanging();
					this._ngayThem = value;
					this.SendPropertyChanged("ngayThem");
					this.OnngayThemChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="SanPham_HoaDon", Storage="_HoaDons", ThisKey="maSP", OtherKey="maSP")]
		public EntitySet<HoaDon> HoaDons
		{
			get
			{
				return this._HoaDons;
			}
			set
			{
				this._HoaDons.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CTloaiSP_SanPham", Storage="_CTloaiSP", ThisKey="maCTloai", OtherKey="maCTloai", IsForeignKey=true)]
		public CTloaiSP CTloaiSP
		{
			get
			{
				return this._CTloaiSP.Entity;
			}
			set
			{
				CTloaiSP previousValue = this._CTloaiSP.Entity;
				if (((previousValue != value) 
							|| (this._CTloaiSP.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._CTloaiSP.Entity = null;
						previousValue.SanPhams.Remove(this);
					}
					this._CTloaiSP.Entity = value;
					if ((value != null))
					{
						value.SanPhams.Add(this);
						this._maCTloai = value.maCTloai;
					}
					else
					{
						this._maCTloai = default(Nullable<int>);
					}
					this.SendPropertyChanged("CTloaiSP");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_HoaDons(HoaDon entity)
		{
			this.SendPropertyChanging();
			entity.SanPham = this;
		}
		
		private void detach_HoaDons(HoaDon entity)
		{
			this.SendPropertyChanging();
			entity.SanPham = null;
		}
	}
}
#pragma warning restore 1591
