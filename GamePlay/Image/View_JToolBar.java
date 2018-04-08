package agi.samples.customapplications.common.viewbar;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

import agi.stkx.*;
import agi.stkobjects.*;

public class View_JToolBar
extends JToolBar
implements ActionListener
{
	private static final long serialVersionUID = 1L;

	public final static int			TEXT_BUTTON_STYLE = 0;
	public final static int			ICON_BUTTON_STYLE = 1;

	public final static String s_HOME_VIEW 		= "Home View";
	public final static String s_3D_ZOOM_IN 	= "3D Zoom In";
	public final static String s_3D_ZOOM_OUT 	= "3D Zoom Out";
	public final static String s_2D_ZOOM_IN 	= "2D Zoom In";
	public final static String s_2D_ZOOM_OUT 	= "2D Zoom Out";
	public final static String s_ORIENT_NORTH	= "Orient North";
	public final static String s_FROM_TO_VIEW	= "From To View";
	
	private IAgStkObjectRoot		m_IAgStkObjectRoot;
	private IAgUiAxVOCntrl			m_IAgUiAxVOCntrl;
	private IAgUiAx2DCntrl			m_IAgUiAx2DCntrl;

	private int						m_IconStyle;
	private boolean					m_UseToolTips;

	private JButton 				m_HomeViewJButton;
	private JButton 				m_OrientNorthJButton;
	private JButton 				m_ZoomIn3DJButton;
	private JButton 				m_ZoomOut3DJButton;
	private JButton 				m_ZoomIn2DJButton;
	private JButton 				m_ZoomOut2DJButton;
	private JButton 				m_FromToViewJButton;
	private JComboBox				m_FromToViewJComboBox;

	public View_JToolBar()
	throws Exception
	{
		this( ICON_BUTTON_STYLE, true );
	}

	public View_JToolBar( boolean useToolTips )
	throws Exception
	{
		this( ICON_BUTTON_STYLE, useToolTips );
	}

	public View_JToolBar( int iconStyle, boolean useToolTips )
	throws Exception
	{
		this.m_IconStyle			= iconStyle;
		this.m_UseToolTips			= useToolTips;
		this.initialize();
	}

	private void initialize()
	throws Exception
	{
		this.setRollover( true );
		this.setFloatable( true );
		this.setVisible( true );

		this.m_HomeViewJButton = new JButton();
		this.m_ZoomIn3DJButton = new JButton();
		this.m_ZoomOut3DJButton = new JButton();
		this.m_ZoomIn2DJButton = new JButton();
		this.m_ZoomOut2DJButton = new JButton();
		this.m_OrientNorthJButton = new JButton();
		this.m_FromToViewJButton = new JButton();
		this.m_FromToViewJComboBox = new JComboBox();

		this.m_HomeViewJButton.setActionCommand( s_HOME_VIEW );
		this.m_ZoomIn3DJButton.setActionCommand( s_3D_ZOOM_IN );
		this.m_ZoomOut3DJButton.setActionCommand( s_3D_ZOOM_OUT );
		this.m_ZoomIn2DJButton.setActionCommand( s_2D_ZOOM_IN );
		this.m_ZoomOut2DJButton.setActionCommand( s_2D_ZOOM_OUT );
		this.m_OrientNorthJButton.setActionCommand( s_ORIENT_NORTH );
		this.m_FromToViewJButton.setActionCommand( s_FROM_TO_VIEW );

		// Set the JComboBox to heavy weight so it does not sit behind the VO/2D controls
		this.m_FromToViewJComboBox.setLightWeightPopupEnabled( false );
		this.m_FromToViewJComboBox.setPreferredSize( new Dimension( 200, 25 ));
		this.m_FromToViewJComboBox.setMinimumSize( new Dimension( 200, 25 ));

		if( this.m_IconStyle == TEXT_BUTTON_STYLE )
		{
			this.m_HomeViewJButton.setText( s_HOME_VIEW );
			this.m_ZoomIn3DJButton.setText( s_3D_ZOOM_IN );
			this.m_ZoomOut3DJButton.setText( s_3D_ZOOM_OUT );
			this.m_ZoomIn2DJButton.setText( s_2D_ZOOM_IN );
			this.m_ZoomOut2DJButton.setText( s_2D_ZOOM_OUT );
			this.m_OrientNorthJButton.setText( s_ORIENT_NORTH );
			this.m_FromToViewJButton.setText( s_FROM_TO_VIEW );
		}
		else if( this.m_IconStyle == ICON_BUTTON_STYLE )
		{
			this.m_HomeViewJButton.setIcon( new ImageIcon(View_JToolBar.class.getResource( "homeview-icon.gif" )) );
			this.m_ZoomIn3DJButton.setIcon( new ImageIcon(View_JToolBar.class.getResource( "zoomin-3d-icon.gif" )) );
			this.m_ZoomOut3DJButton.setIcon( new ImageIcon(View_JToolBar.class.getResource( "zoomout-3d-icon.gif" )) );
			this.m_ZoomIn2DJButton.setIcon( new ImageIcon(View_JToolBar.class.getResource( "zoomin-2d-icon.gif" )) );
			this.m_ZoomOut2DJButton.setIcon( new ImageIcon(View_JToolBar.class.getResource( "zoomout-2d-icon.gif" )) );
			this.m_OrientNorthJButton.setIcon( new ImageIcon(View_JToolBar.class.getResource( "orientnorth-icon.gif" )) );
			this.m_FromToViewJButton.setIcon( new ImageIcon(View_JToolBar.class.getResource( "fromtoview-icon.gif" )) );
		}

		if( this.m_UseToolTips )
		{
			ToolTipManager.sharedInstance().setLightWeightPopupEnabled( false );

			this.m_HomeViewJButton.setToolTipText( s_HOME_VIEW );
			this.m_ZoomIn3DJButton.setToolTipText( s_3D_ZOOM_IN );
			this.m_ZoomOut3DJButton.setToolTipText( s_3D_ZOOM_OUT );
			this.m_ZoomIn2DJButton.setToolTipText( s_2D_ZOOM_IN );
			this.m_ZoomOut2DJButton.setToolTipText( s_2D_ZOOM_OUT );
			this.m_OrientNorthJButton.setToolTipText( s_ORIENT_NORTH );
			this.m_FromToViewJButton.setToolTipText( s_FROM_TO_VIEW );
		}

		this.add( this.m_HomeViewJButton );
		this.add( this.m_ZoomIn3DJButton );
		this.add( this.m_ZoomOut3DJButton );
		this.add( this.m_ZoomIn2DJButton );
		this.add( this.m_ZoomOut2DJButton );
		this.add( this.m_OrientNorthJButton );
		this.add( this.m_FromToViewJButton );
		this.add( this.m_FromToViewJComboBox );

		this.m_HomeViewJButton.addActionListener( this );
		this.m_ZoomIn3DJButton.addActionListener( this );
		this.m_ZoomOut3DJButton.addActionListener( this );
		this.m_ZoomIn2DJButton.addActionListener( this );
		this.m_ZoomOut2DJButton.addActionListener( this );
		this.m_OrientNorthJButton.addActionListener( this );
		this.m_FromToViewJButton.addActionListener( this );
	}

	public void setVO( IAgUiAxVOCntrl vo )
	{
		this.m_IAgUiAxVOCntrl = vo;
	}

	public void setMap( IAgUiAx2DCntrl map )
	{
		this.m_IAgUiAx2DCntrl = map;
	}

	public void setRoot( IAgStkObjectRoot root )
	{
		this.m_IAgStkObjectRoot = root;
	}
	
	public void setEnabled( boolean enabled )
	{
		super.setEnabled( enabled );
		this.m_HomeViewJButton.setEnabled( enabled );
		this.m_OrientNorthJButton.setEnabled( enabled );
		this.m_ZoomIn3DJButton.setEnabled( enabled );
		this.m_ZoomOut3DJButton.setEnabled( enabled );
		this.m_ZoomIn2DJButton.setEnabled( enabled );
		this.m_ZoomOut2DJButton.setEnabled( enabled );
		this.m_FromToViewJButton.setEnabled( enabled );
		this.m_FromToViewJComboBox.setEnabled( enabled );
	}

	public void actionPerformed( ActionEvent ae )
	{
		try
		{
			String cmd = ae.getActionCommand();

			if( cmd.equalsIgnoreCase( s_HOME_VIEW ) )
			{
				if( this.m_IAgUiAxVOCntrl != null && this.m_IAgStkObjectRoot != null )
				{
					this.m_IAgStkObjectRoot.executeCommand( "VO * View Home");
				}
			}
			else if( cmd.equalsIgnoreCase( s_3D_ZOOM_IN ) )
			{
				if( this.m_IAgUiAxVOCntrl != null )
				{
					this.m_IAgUiAxVOCntrl.zoomIn();
				}
			}
			else if( cmd.equalsIgnoreCase( s_3D_ZOOM_OUT ) )
			{
				if( this.m_IAgUiAxVOCntrl != null && this.m_IAgStkObjectRoot != null )
				{
					this.m_IAgStkObjectRoot.executeCommand( "VO * View Home");
				}
			}
			else if( cmd.equalsIgnoreCase( s_2D_ZOOM_IN ) )
			{
				if( this.m_IAgUiAx2DCntrl != null )
				{
					this.m_IAgUiAx2DCntrl.zoomIn();
				}
			}
			else if( cmd.equalsIgnoreCase( s_2D_ZOOM_OUT ) )
			{
				if( this.m_IAgUiAx2DCntrl != null )
				{
					this.m_IAgUiAx2DCntrl.zoomOut();
				}
			}
			else if( cmd.equalsIgnoreCase( s_ORIENT_NORTH ) )
			{
				if( this.m_IAgUiAxVOCntrl != null && this.m_IAgStkObjectRoot != null )
				{
					this.m_IAgStkObjectRoot.executeCommand( "VO * View North");
				}
			}
			else if( cmd.equalsIgnoreCase( s_FROM_TO_VIEW ) )
			{
				if( this.m_IAgUiAxVOCntrl != null && this.m_IAgStkObjectRoot != null )
				{
					String objectName = ( String )this.m_FromToViewJComboBox.getSelectedItem();

					this.viewObject( objectName );
				}
			}
		}
		catch( Throwable t )
		{
			t.printStackTrace();
		}
	}

	public void addFromToViewEntry( String entry )
	{
		this.m_FromToViewJComboBox.addItem( entry );
	}

	public void removeFromToViewEntry( String entry )
	{
		this.m_FromToViewJComboBox.removeItem( entry );
	}

	public void clearEntries()
	{
		this.m_FromToViewJComboBox.removeAllItems();
	}
	
	public void viewObject( String objectName )
	{
		try
		{
			if( objectName != null )
			{
				if( !objectName.equalsIgnoreCase("") )
				{
					StringBuffer sb = new StringBuffer();
					
					sb.append( "VO * ViewFromTo Normal From " );
					sb.append( objectName );
					sb.append(" To " );
					sb.append( objectName );
					
					this.m_IAgStkObjectRoot.executeCommand( sb.toString() );
				}
			}
		}
		catch( Throwable t )
		{
			t.printStackTrace();
		}
	}
}