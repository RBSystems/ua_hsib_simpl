import sys

file_location = ""

if len(sys.argv) > 1:
    file_location = str(sys.argv[1])
else:
    print("--Err: no filename provided")
    exit()

keys = {    "local_name"        :0,
            "room_ass"          :1,
            "local_id"          :2,
            "function_id"       :3,
            "filter"            :4,
            "is_virtual"        :5,
            "local_src_id"      :6,
            "sys_preset"        :7,
            "device_type"       :8,
            "ip_address"        :9,
            "is_display"        :10,
            "is_camera"         :11,
            "is_vtc"            :12,
            "com_port"          :13,
            "processor_index"   :14,
            "cmd_io"            :15,
            "usb_mac"           :16,
            "relay_proc"        :17,
            "rly_on"            :18,
            "rly_off"           :19,
            "vtc_io"            :20     }
values = []


file_data = open(file_location, mode="r", encoding="utf-8").read()
line_data = file_data.split("\n")
kv_data = []
new_data = ""

for i in range(21):
    values.append("")


for line in line_data:
    temp_line = str(line)
    k = ""
    v = ""

    if "//" in line:
        new_data += line
        new_data += "\n"
    elif len(temp_line.strip()) == 0:
        new_data += "\n"
    else:
        kv_data = line.split(",")
        for i in range(21):
            values[i] = ""
        for kv in kv_data:
            print(kv)
            if "=" not in kv:
                continue
            [k,v] = kv.split("=")
            for key in keys:
                if key in k:
                    values[keys[key]] = str(v)
                    break

        for i in range(21):
            new_data += values[i]
            new_data += ","
        new_data += "\n"

print(new_data)

new_file_location = file_location[:-4] + "__.csv"

new_file = open(new_file_location, "w+", encoding="utf-8").write(new_data)


