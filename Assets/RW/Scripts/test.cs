using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using static Unity.Collections.AllocatorManager;
using UnityEngine.WSA;
using System.ComponentModel;
using System.Drawing;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEditor.Experimental.GraphView;
using static UnityEditor.PlayerSettings;
using UnityEngine.U2D;
using static System.Collections.Specialized.BitVector32;
using static Unity.Burst.Intrinsics.X86;
using System.Xml.Linq;
using System;
using UnityEditor;
using static UnityEngine.UIElements.VisualElement;
using UnityEngine.UIElements;
using static UnityEngine.ParticleSystem;
using UnityEngine.Android;
using UnityEngine.SocialPlatforms;
using UnityEngine.XR;
using static UnityEditor.Experimental.GraphView.GraphView;
using System.Numerics;
using UnityEngine.UIElements.Experimental;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.Profiling;
using UnityEngine.UI;
using System.Data.Common;
using UnityEditor.PackageManager;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       paste code vào trước
       Part 1:
       Cấu trúc thư mục:
            * Assests:
                - Audio
                - RW
                  + Scripts
                  + Animations
                  + Prefabs
                  + Scenes
                - Sprites

        Cấu hình Game View:
            - Set resolution qua cửa sổ Game View thành 1136×640 với tên là "iPhone Landscape".
            - Chọn Camera trong Hierarchy và set Size là 3.2.

        Thêm nhân vật: 
            - Kéo folder "Audio" và "Sprites" vào thư mục "Assets".
            - Tìm và chọn mouse_sprite_sheet, đặt Sprite Mode thành Multiple ở Inspector, nhấn Apply.
            - Click nút Sprite Editor, cửa số hiện lên, ấn Slice:
                + 1.Đặt Type field là Grid By Cell Size.
                + 2.Đặt Pixel Size là 162 x 156.
                + 3.Click Slice.
                + 4.Apply để lưu.
            - Ở trong Sprite Editor, Chọn ảnh góc trái trên. Sửa tên thành: mouse_run_0:
                Sửa lần lượt thành :
                	mouse_run_1
                	mouse_run_2
                	mouse_run_3
                	mouse_fly
                    mouse_fall
                    mouse_die_0
                	mouse_die_1.  Nhớ Apply.
            - chọn mouse_fly và kéo nó vào Scene:
                1.Sửa tên thành mouse
                2.Set Position là (0, 0, 0).
                3.Clicking Add Component trong Inspector. Tìm chọn Circle Collider 2D.
                4.Đặt Radius của Circle Collider 2D component là 0.5.
                5.Thêm Rigidbody 2D component by clicking Add Component and selecting Physics 2D\Rigidbody 2D.
                6.Mở phần constraints ở trong Rigidbody 2D component. Tích vào Freeze Rotation Z checkbox.


         Tạo Script:
            - trong mục scripts, tạo mới C# script, nhớ đặt đúng tên từ đầu. (MouseController).
            - Kéo script vào đối tượng "mouse".

        Điều chỉnh trọng lực:
            - chọn Menu Edit ở bên trên cùng ý, ▸ Project Setting ▸ Physics 2D.
            - Tìm Gravity sửa Y thành -15.

        Thêm floor và celling:
            - Chuột phải vào Hierarchy chọn Create Empty:
                1.Sửa tên thành floor.
                2.Sửa Position thành [ 0, -3.3, 0].
                3.Sửa Scale thành (14.4, 1, 1).
                4.Click Add Component and add a Box Collider 2D component by selecting Physics 2D\Box Collider 2D.
            - Tương tự với celling, đặt Position là[0, 3.7, 0].

        Sử dụng Particle System để tạo Jetpack Flames:
            - Chuột phải vào Hierarchy ▸ Effects ▸ Particle System:
                1.Đổi tên Particle System thành jetpackFlames .
                2.Đặt Position là (-0.62, -0.33, 0)
                3.Đặt Rotation là (65, 270, 270)
                4.Vẫn ở trong Inspector, tìm Particle System component và đặt những thuộc tính sau:
                	Đặt Start Lifetime là 0.5
                	Set Start Size to 0.3
                	Click on Start Color and set Red to 255, Green to 135, Blue to 40 and leave Alpha at 255.
                	Expand the Emission section and set ""Rate over Time"" to 300.
                	Expand the Shape section. Make sure Shape: Cone, set Angle: 12; Radius: 0.1;  Randomize Direction: 1.
                   Mở "Color over Lifetime". Tích vào checkbox. Ấn vào màu (Trắng), chọn góc phải trên, kéo Alpha về 0.

        Thêm Backgrounds:
            - kéo backgound vào scene. ấn giữ V và ấn kéo chuột trái vào góc cạnh của background để căn chỉnh.

        Sử dụng sắp xếp Layers:
            - chọn mouse ở Hierarchy và tìm Sprite Renderer ở trong Inspector. 
            - ấn vào và chọn Add Sorting Layer:
                Background
                Decorations
                Objects
                Player
            - Chọn mouse ở Hierarchyvà đặt Sorting Layer là Player.
            - bg_window, bg và bg(1) ở thì đặt Sorting Layers là Background.
            - Chọn jetpackFlames trong Hierarchy. Ở Inspector tìm Renderer ở cuối phần Particle System và ấn mở rộng nó.
            - đặt Sorting Layer thành Player và Order in Layer là -1.
        
        Trang trí room:
            - Tự thêm trang trí

       


       PART 2:
       Making the Camera Follow the Player:
        - Trong RW/Scripts tạo mới C# Script tên là "CameraFollow". Kéo vào Main Camera ở Hierarchy.
        - set Position thành (-3.5, 0, 0)
        - Chọn Main Camera ở Hierarchy.
        - Kéo mouse ở Hierarchy vào CameraFollow script ở Main Camera.
        Generating an Endless Level:
            - Tạo gameobject mới, đổi tên thành room1. Set Position to (0, 0, 0).
            - Kéo các phần(bg, bg (1), bg_window, ceiling, floor, object_bookcase_short1, object_mousehole) vào room1.
            - Kéo room1 ở Hierarchy vào trong Prefabs folder.
            - Kéo room1 Prefab vào scene.
            - Thêm GeneratorScript vào mouse.
            - trong GeneratorScript ở Inspector, Kéo room1 ở Hierarchy vào Current Rooms list.
            - Mở Prefabs ở Project view và kéo room1 vào Available Rooms. (có thể tạo room2 r thêm vào or not).

        Animating the Mouse:
            - Chọn Animations folder.
            - Creating Animations: ctrl 6 (Window ▸ Animation ).
            - Chọn Animations folder.
            - Chọn mouse GameObject ở Hierarchy.
            - trong Animation window, click Create và đặt tên là run, tạo cái nữa và đặt là fly.

        Adding Run Animation Frames:
            - Trong Animation view, select the run animation.
            - Chọn và kéo mouse_run_0, mouse_run_1, mouse_run_2, mouse_run_3 vào Animation view's timeline.
            - set the Samples property to 8 instead of 60.
            - Làm tương tự với 1 mình fly. ( k0 set sapmles).
            - Chọn mouse ở Hierarchy tìm Animator trong Inspector.
            - Chọn Update Mode dropdown box và sửa Normal thành Animate Physics.

        Creating Animation Transitions:
            - Window ▸ Animator. ( Selected the mouse in Hierarchy )
            - Đảm bảo đã có run và fly.
            - right-click the run animation and select Make Transition, di chuột sang fly animation and left-click on it.
            - làm tương tự ngược lại.

        Adding a Transition Parameter:
            - Mở Animator view và tìm Parameters panel ở góc trái trên.
            - ban đầu trống (empty).Click nút dấu cộng "+" to add a parameter. chọn Bool.
            - Đặt tên parameter mới là isGrounded.
            - chọn transition from run to fly to open transition properties in the Inspector.
            - Ở phần Conditions, click the plus to add isGrounded and set its value to false.
            - Uncheck Has Exit Time, expand the Settings for transition. Set Transition Duration = 0.
            - Làm tương tự transition from fly to run, nhưng set isGrounded value to true.

        Checking if the Mouse is Grounded:
            - Tạo GameObject mới, kéo vào trong mouse ở Hierarchy. đổi tên nó là groundCheck.Set Position (0, -0.7, 0).
            - Để nhìn thấy nó trên scene, click nút icon ở Inspector và chọn màu xanh lá.

        Using Layers to Define What is Ground:
            - Mở Prefabs folder trong Project view, mở rộng room1 Prefab. Chọn floor trong Prefab.
            - Trong Inspector, click Layer chọn Add Layer... .
            - Viết "Ground" vào User Layer 8.
            - Chọn lại floor như vừa rồi phát nữa rồi sửa layer thành ground.

        Setting the MouseController Script Parameters for Ground Check:
            - Chọn mouse, ở trong mouseController script: Ground Check Layer Mask = Ground.
            - Kéo groundCheck ở Hierarchy vào phần Ground Check Transform.


        Enabling and Disabling the Jetpack Flames:
            - Kéo jetpackFlames ở Hierarchy vào Jetpack trong mouseController script.
        

}
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
